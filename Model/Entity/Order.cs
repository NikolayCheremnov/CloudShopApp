namespace CloudShopApp.Model.Entity
{
    // класс "Заказ в магазине"
    public class Order
    {
        public int Id { get; set; }
        public string FeedbackContact { get; set; } // данные обратной связи клиента
        public string Description { get; set; }     // описание заказа

        public override string ToString()
        {
            return $"{Id} - {FeedbackContact} - {Description}";
        }
    }
}
