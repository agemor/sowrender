## Product
Product(string modelName, string color, string capacity)
Product(string modelName, string explanation, int price, int inventory, string color, string capacity)
private string modelName {get}
private string explanation {get}

#### attribute{
  private int price {get}
  private int inventory {get}
  private string color {get}
  private string capacity {get}
#### }

## ProductManager
private List<Product> productInfo {get}

public void Refound(Product p)
getInstance()


##CustomerManager
private Dictionary<string, Customer> customerData

getInstance()

public void AddCustomerData(Customer c)
private void Modify(string phone, Customer customer)
public void DeleteCustomerData(string phone)

## Customer
Customer()
Customer(name, phoneNumber, shippingAddress, count)

private string name
private string phoneNumber
private shippingAddress
private int count // 주문 횟수

## SalesManager
ProductManager product
CustomerManager customer

public bool Refund() //환불
private bool PerchaseCheck()

getInstance()


## static ProductStatistics
private List<SalesManager> reciept {get;}

private Dictionary<string, SalesManager> salesAmountByModel

private List totalSalesAmount



exportAsCsv() // CSV로 내보내기


