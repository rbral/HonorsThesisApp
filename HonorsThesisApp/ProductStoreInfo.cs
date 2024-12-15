namespace HonorsThesisApp
{
    public class ProductStoreInfo
    {
        public double totalPrice = 0.0;
        public List<string> productNames;
        public ProductStoreInfo(double totalPrice, List<string> productNames)
        {
            this.totalPrice = totalPrice;
            this.productNames = productNames;

        }

        public ProductStoreInfo(double totalPrice)
        {
            this.totalPrice = totalPrice;
            this.productNames = new List<string>();
;
        }
    }
}