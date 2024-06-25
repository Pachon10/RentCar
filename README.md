# RentCar

## How the problem is covered.

Let's say, a user can rent one or several cars, so we understand that we must have a Rentals entity in which we will have the information of each rental per user.

Although Loyalty points are mentioned, I have decided to treat it as a benefit that is achieved by renting the car and I have not treated it as an entity and therefore it is a property of the entity Rentals.

Cars are identified as an inventory, but the API functionality does not indicate that a rented car cannot be rented in the same time period, so I have ignored the inventory part and just have a car relationship with CarType.

Users are also not managed, so if a user does not exist it is automatically "created" and will have a list of rented cars.

Entity Rents:

```cs
public enum CarType
{
    Premium,
    SUV,
    Small
}

public class Rents
{
    public Rents(
        string carName,
        CarType carType,
        string nameUser,
        int loyaltyPoints,
        DateTime from,
        DateTime to,
        double totalPrice,
        double extraPrice)
    {
        CarName = carName;
        CarType = carType;
        NameUser = nameUser;
        LoyaltyPoints = loyaltyPoints;
        From = from;
        To = to;
        TotalPrice = totalPrice;
        ExtraPrice = extraPrice;
    }

    public string CarName { get; }
    public CarType CarType { get; }
    public string NameUser { get; }
    public int LoyaltyPoints { get; }
    public DateTime From { get; }
    public DateTime To { get; }
    public double TotalPrice { get; }
    public DateTime? ReturnedDate { get; private set; }
    public double ExtraPrice { get; private set; }
}
```

For this problem two end-points have been requested, one for the rental and one for the return.

As base data we will have:

Prices: 
- premium price: 300€ 
- SUV price: 150€ 
- small price: 50€ 

Coches:
- BMW 7 (Premium)
- Kia Sorento (SUV)
- Nissan Juke (SUV)
- Seat Ibiza (Small)

LoyaltyPoints:
- Premium car: 5 points. 
- SUV car: 3 points. 
- Small car: 1 point. 


## How to use it?
We have 2 final points:
- POST /Rents/RentingCars
	- In which we can rent one or more cars per user. 
- PUT /Rents/ReturnedCars
	- We will return one or more cars per user.

It has swagger enabled for easier data interpretation.

### End-Point RetingCars

DTO entry
```json
{
  "userName": "string",
  "cars": [
    {
      "carName": "string",
      "from": "2024-06-25T09:37:14.534Z",
      "to": "2024-06-25T09:37:14.534Z"
    }
  ]
}
```

In which all fields are required.

The user can be any user (a new user will be created if it does not exist).

And the From must be less than the To.

#### Example 
```json
{
  "userName": "Daniel",
  "cars": [
    {
      "carName": "BMW 7",
      "from": "2024-06-01T09:37:14.534Z",
      "to": "2024-06-11T09:37:14.534Z"
    }
  ]
}
```

Return: 
```json
BMW 7 (Premium) 10 days -> 3000€
```

### End-Point ReturnedCars

DTO entry
```json
{
  "userName": "string",
  "cars": [
    {
      "carName": "string",
      "returnedDate": "2024-06-25T10:46:45.018Z"
    }
  ]
}
```

All fields are required.

The user must be a user who has rented a car.

The car name must be from a car rented by that user.

The return date must be greater than the rental date.

#### Example

```json
{
  "userName": "Daniel",
  "cars": [
    {
      "carName": "BMW 7",
      "returnedDate": "2024-06-13T09:37:14.534"
    }
  ]
}
```

Return: 
```json
BMW 7 (Premium) 2 extra days -> 720€
```

