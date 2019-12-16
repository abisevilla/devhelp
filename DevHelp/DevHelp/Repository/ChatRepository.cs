using DevHelp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevHelp.Repository
{
    public class ChatRepository :IChat
    {
        private ChatEntities DBcontext;

        public ChatRepository(ChatEntities objempcontext)

        {

            this.DBcontext = objempcontext;

        }
        #region Messages
        public IEnumerable<Messages> GetMesagges()
        {
            return DBcontext.Messages.ToList();
        }

        public void InsertMessages(Models.Messages msg)

        {

            DBcontext.Messages.Add(msg);

            DBcontext.SaveChanges();

        }


        public Messages GetMessagesByUserID(int PostreId)
        {
            return DBcontext.Messages.Find(PostreId);
        }
        #endregion


        #region Users

        public IEnumerable<Users> GetUsers()
        {
            return DBcontext.Users.ToList();
        }
        public void InsertUser(Models.Users user)

        {

            DBcontext.Users.Add(user);

            DBcontext.SaveChanges();

        }
        public void UpdateUser(Models.Users user)

        {

            DBcontext.Entry(user).State = EntityState.Modified;

            DBcontext.SaveChanges();

        }



        #endregion

        #region Rooms

        public IEnumerable<Rooms> GetRooms()
        {
            return DBcontext.Rooms.ToList();
        }

        public void InsertRoom(Models.Rooms room)

        {

            DBcontext.Rooms.Add(room);

            DBcontext.SaveChanges();

        }

        #endregion


        #region RoomsMessages




        #endregion
    }
}