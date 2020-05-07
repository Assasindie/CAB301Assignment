using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CAB301Assignment
{
    class MemberCollection
    {
        public Member[] MembersArray = new Member[0];

        public void InsertMember(Member Member)
        {
            Array.Resize(ref MembersArray, MembersArray.Length + 1);
            MembersArray[^1] = Member;
        }

        public string SearchMemberNumber(string UserName)
        {
            for (int i = 0; i < MembersArray.Length; i++)
            {
                if(MembersArray[i].UserName == UserName)
                {
                    return MembersArray[i].PhoneNumber;
                }
            }
            return "User Not Found";
        }
    }
}
