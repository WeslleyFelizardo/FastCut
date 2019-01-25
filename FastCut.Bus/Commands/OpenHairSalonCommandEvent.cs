using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Bus.Commands
{
    public class OpenHairSalonCommandEvent : CommandEvent
    {
        public OpenHairSalonCommandEvent(int id, string name, string nickName)
        {
            Id = id;
            Name = name;
            NickName = nickName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string NickName { get; private set; }
    }
}
