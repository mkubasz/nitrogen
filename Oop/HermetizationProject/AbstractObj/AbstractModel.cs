namespace AbstractObj
{
    public abstract class AbstractModel
    {
        public abstract void Drive();
        public abstract string Steady();

        public string Body()
        {
            return "szkielet";
        }

    }
}