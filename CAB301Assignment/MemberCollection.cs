using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CAB301Assignment
{
    class MemberCollection
    {
        public Member[] MembersArray = new Member[0];

        public void InsertMember(Member Member) //inserts a new member by resizing array and adding them at the end
        {
            Array.Resize(ref MembersArray, MembersArray.Length + 1);
            MembersArray[^1] = Member;
        }

        public string SearchMemberNumber(string UserName) //loops through the array to find matching username and returns phone number or not found.
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
