namespace Duo1J
{
    public class AnimationModel : AVGModel
    {
        private string type;

        public AnimationModel(string type)
        {
            this.Type = type;
        }

        public string Type { get => type; set => type = value; }
    }
}