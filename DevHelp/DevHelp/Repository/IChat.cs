using DevHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHelp.Repository
{
    interface IChat
    {
        #region Messages
        IEnumerable<Models.Messages> GetMesagges();
        void InsertMessages(Models.Messages msg);
        Messages GetMessagesByUserID(int PostreId);



        #endregion

        #region User
        IEnumerable<Users> GetUsers();
        void InsertUser(Models.Users user);
        void UpdateUser(Models.Users user);

        #endregion

        #region Rooms
        IEnumerable<Rooms> GetRooms();
        void InsertRoom(Models.Rooms room);

        #endregion
    }
}
