using System;

namespace notelab.app.Model
{
    public class Notes
    {
        public int Id {get; init;}
        public string Title {get; init;}
        public string Note {get; init;}
        public DateTime Time {get; init;}
        public int UsersId {get; set;}
        // public Users Users {get; set;}
    }
}
