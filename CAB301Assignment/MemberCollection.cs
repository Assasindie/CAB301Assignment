using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CAB301Assignment
{
    class MemberCollection
    {
        Member[] Members = new Member[0];

        public void InsertMember(Member Member)
        {
            Array.Resize(ref Members, Members.Length + 1);
            Members[^1] = Member;
        }

        public string SearchMemberNumber(string UserName)
        {
            for (int i = 0; i < Members.Length; i++)
            {
                if(Members[i].UserName == UserName)
                {
                    return Members[i].PhoneNumber;
                }
            }
            return "User Not Found";
        }
    }
}
