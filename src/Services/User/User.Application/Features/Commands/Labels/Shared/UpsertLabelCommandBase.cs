namespace User.Application.Features.Commands.Labels.Shared
{
    public class UpsertLabelCommandBase
    {
        public int RedColor { get; set; }
        public int GreenColor { get; set; }
        public int BlueColor { get; set; }
        public string Name { get; set; }
    }
}