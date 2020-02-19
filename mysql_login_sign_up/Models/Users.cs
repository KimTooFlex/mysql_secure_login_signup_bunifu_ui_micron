using Micron;
using System;
using System.Collections.Generic;

namespace Data.Models
{
/***USER MODEL***/
  [Table("users")]
 public partial class User : IMicron
 {
        [Primary]
        public Int32 id {get; set;}
        public String Name {get; set;}
        public String Email {get; set;}
        public String Password {get; set;}
 }
}
