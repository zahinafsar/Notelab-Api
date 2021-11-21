// using System;
// using System.Collections.Generic;
// using notelab.app.Model;

// namespace notelab.app.Data
// {
//     public class Database
//     {
//         private List<User> _users = new()
//         {
//             new User {
//                 username = "zahinafsar",
//                 password = "zahin123",
//                 note = new Note[]
//                 {
//                     new Note {
//                         creator = "zahinafsar",
//                         title = "First post",
//                         note = "This is my first post",
//                         time = DateTime.UtcNow
//                     },
//                     new Note {
//                         creator = "zahinafsar",
//                         title = "Second post",
//                         note = "This is my second post",
//                         time = DateTime.UtcNow
//                     }
//                 }
//             },
//             new User {
//                 username = "nurulhuda",
//                 password = "nurul123",
//                 note = new Note[]
//                 {
//                     new Note {
//                         creator = "nurulhuda",
//                         title = "First post",
//                         note = "This is my first post",
//                         time = DateTime.UtcNow
//                     }
//                 }
//             },
//             new User {
//                 username = "jubayeralmamun",
//                 password = "jubayer123",
//                 note = new Note[]
//                 {
//                     new Note {
//                         creator = "jubayeralmamun",
//                         title = "First post",
//                         note = "This is my first post",
//                         time = DateTime.UtcNow
//                     },
//                     new Note {
//                         creator = "jubayeralmamun",
//                         title = "Second post",
//                         note = "This is my second post",
//                         time = DateTime.UtcNow
//                     },
//                     new Note {
//                         creator = "jubayeralmamun",
//                         title = "Third post",
//                         note = "This is my third post",
//                         time = DateTime.UtcNow
//                     }
//                 }
//             },
//         };

//         public IEnumerable<User> Data()
//         {
//             return _users;
//         }
//     }
// }
