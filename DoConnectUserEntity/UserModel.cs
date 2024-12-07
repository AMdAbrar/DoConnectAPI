using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoConnectUserEntity
{
    public class UserModel
    {
        public int QId { get; set; }
        public string topicname { get; set; }
        public string Question { get; set; }
        public int UserId { get; set; }

    }
    public class AnswerModel
    {
        public int AId { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }

    }
    public class CommentModel
    {
        public int CId { get; set; }
        public string Comment { get; set; }
        public DateOnly Commentdate { get; set; }
        public string CommentStatus { get; set; }
    }
}
