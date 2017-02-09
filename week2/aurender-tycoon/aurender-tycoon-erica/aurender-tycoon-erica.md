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

getInstance()


##CustomerManager
private Dictionary<string, Customer> customerData

getInstance()

public void AddCustomerData(Customer c)
private void Modify(string phone, Custo mer customer)
public void DeleteCustomerData(string phone)

## Customer
Customer()
Customer(name, phoneNumber, shippingAddress, count)

private string name
private string phoneNumber
private shippingAddress
private int count // 주문 횟수

## SalesManager
private ProductManager product = getInstance()
private CustomerManager customer = getInstance()



public bool Purchase(Product p, Customer c)



public bool Refund() //환불
private bool PurchaseCheck()

getInstance()


## static ProductStatistics
private List<SalesManager> reciept {get;}

private Dictionary<string, SalesManager> salesAmountModel

private List totalSalesAmount



public void exportAsCsv() // CSV로 내보내기


