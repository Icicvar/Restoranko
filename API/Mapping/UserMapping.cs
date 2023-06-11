using API.BLClass;
using API.Models;

namespace API.Mapping
{
    public class UserMapping
    {
        public static IEnumerable<BLUser> MapToBL(IEnumerable<User> audios) =>
            audios.Select(x => MapToBL(x));

        public static BLUser MapToBL(User audio) =>
            new BLUser
            {
                Iduser = audio.Iduser,
                FirstName = audio.FirstName,
                LastName = audio.LastName,
                Email = audio.Email,
                Password = audio.Password,
                UserTypeId = audio.UserTypeId,
                
                UserType = audio.UserType,
            };
    }
}
