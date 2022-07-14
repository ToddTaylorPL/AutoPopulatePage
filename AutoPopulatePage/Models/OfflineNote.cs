
namespace AutoPopulatePage.Models
{
    public class OfflineNote
    {
        [PrimaryKey, AutoIncrement]
        public int OfflineNoteId { get; set; }
        public bool IsClosed { get; set; }
        public string Note { get; set; }
        
    }
}
