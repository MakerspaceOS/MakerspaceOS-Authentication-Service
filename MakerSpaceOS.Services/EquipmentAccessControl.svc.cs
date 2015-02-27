using System.Collections.Generic;
using System.Linq;
using MakerSpaceOS.Data;
using MakerSpaceOS.Services.Interfaces;

namespace MakerSpaceOS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Access" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Access.svc or Access.svc.cs at the Solution Explorer and start debugging.
    public class EquipmentAccessControl : IEquipmentAccessControl
    {
        public EquipmentAccessResponse CheckEquipmentAccess(string equipmentId, string rfidCode, string pin)
        {
            if (pin == "~")
            {
                pin = null;  //Service does not like empty pin, so the sketch sends # instead
            }
            var model = new MakerSpaceOSEntities();
            //First lets see if the RFID tag belongs to a valid member.
            RFIDTag rfidRecord =
                (from rfid in model.RFIDTags
                    where rfid.RFIDCode == rfidCode && (rfid.PIN == pin || pin == null)
                    select rfid).FirstOrDefault();


            if (rfidRecord != null)
            {
                if (!string.IsNullOrEmpty(pin) && rfidRecord.PIN != pin)
                {
                    return new EquipmentAccessResponse {AccessAllowed = "false", Message = "Incorrect PIN"};
                }
                //We found the RFID and Member, so let find the equipment and see if the user has had training and has access.
                Equipment equipment =
                    (from equipe in model.Equipments where equipe.EquipmentSiteUniqueID == equipmentId select equipe)
                        .FirstOrDefault();

                if (equipment != null)
                {
                    if (!equipment.RequiresTrainingCourse)
                    {
                        //No training required, so we can allow the access.
                        return new EquipmentAccessResponse
                        {
                            AccessAllowed = "true",
                            UserName = string.Format("{0} {1}", rfidRecord.Member.FirstName, rfidRecord.Member.LastName),
                            TimeLimit = equipment.TimeLimitMinutes,
                            AmpsWhenOn = equipment.AmpsWhenOn
                        };
                    }
                    //Determine if the member has had the training required.
                    //Get the required training courses and then see if the member has taken and passed all of the classes.
                    IEnumerable<int> requiredCourseIds = (from training in equipment.EquipmentTrainingCourses
                        where training.RequiredForUse
                        select training.TrainingCourseID);

                    //We really only care that they passed all the required classes, so we can compare counts and don't need to know the exact course.  
                    //In the future maybe we want to tell the user what course, but that seems overkill right now.  Thoughts??
                    int passedCourseCount = (from m in rfidRecord.Member.MembersTrainingCourses
                        where m.PassedCourse && requiredCourseIds.Contains(m.TrainingCourseID)
                        select m).Count();

                    if (requiredCourseIds.Count() == passedCourseCount)
                    {
                        return new EquipmentAccessResponse
                        {
                            AccessAllowed = "true",
                            UserName = string.Format("{0} {1}", rfidRecord.Member.FirstName, rfidRecord.Member.LastName),
                            TimeLimit = equipment.TimeLimitMinutes,
                            AmpsWhenOn = equipment.AmpsWhenOn
                        };
                    }
                    return new EquipmentAccessResponse
                    {
                        AccessAllowed = "false",
                        Message = "Required training not completed"
                    };
                }
                return new EquipmentAccessResponse {AccessAllowed = "false", Message = "Incorrect Equipment ID"};
            }
            return new EquipmentAccessResponse {AccessAllowed = "false", Message = "Incorrect RFID"};
        }
    }
}