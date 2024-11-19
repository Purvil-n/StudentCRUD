namespace StudentCRUD.RequestResponse
{
    public class Response
    {
        public int StudentId { get; set; } = 0; //same fieldname as StudentEntity or different like this
        public string StudentName { get; set; } = string.Empty;
        public string StudentMobile { get; set; } = string.Empty;
    }

}
