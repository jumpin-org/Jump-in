namespace Admin.Domain.Modles
{
    public class FicaDetail
    {
        public int FicaDetailId { get; set; }
        public byte[] Document { get; set; }
        public int FicaStatusId { get; set; }
        public FicaStatus FicaStatus { get; set; }
    }
}
