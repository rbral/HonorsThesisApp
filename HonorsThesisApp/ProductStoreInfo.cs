namespace HonorsThesisApp
{
    public class ProductStoreInfo
    {
        public double totalPrice = 0.0;
        public List<string> productNames = new List<string>();
        public ProductStoreInfo(double totalPrice, List<string> productNames)
        {
            this.totalPrice = totalPrice;
            this.productNames = productNames;

        }
    }
}