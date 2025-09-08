# Shopping Cart Application

A full-stack application that calculates the final bill amount based on customer type and purchase amount, applying slab-based discounts. Built with ASP.NET Core Web API.

---

## 📌 Features

- Supports two customer types: **Regular** and **Premium** 
- Applies progressive discount slabs based on purchase amount that would be extended or changed easily since its *Enum*
- RESTful API for billing calculation
- Unit-tested discount logic for reliability

---

## 🧱 Tech Stack

| Layer      | Technology         |
|------------|--------------------|
| Backend    | ASP.NET Core (.NET 7) |
| Testing    | xUnit (.NET)       |
| API Protocol | JSON over HTTP    |

---

### 🔧 Backend Setup (.NET Core)

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/shopping-cart.git
   cd shopping-cart/backend
