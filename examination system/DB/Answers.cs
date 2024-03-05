
using System.ComponentModel.DataAnnotations;


namespace examination_system.DB
{
    public class Answers
    {
        [Key]
        public int AnswerId { get; set; }
        public string Option_one { get; set; }
        public string Option_tow { get; set; }
        public string Option_three { get; set; }
        public string Option_four { get; set; }

        public string CorectAns { get; set; }
                                            
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
