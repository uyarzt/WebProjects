using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppForTesting.Models.TestingModels
{
    public class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Quest { get; set; }       
        public int TestId { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual TestType TestType { get; set; }
    }
}