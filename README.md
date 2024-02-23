# Restaurant API README

Welcome to the Restaurant API application! This API provides endpoints to manage menu items, categories, and orders of food in a restaurant.

## Overview

The Restaurant API allows users to perform the following operations:

- Retrieve menu items and categories
- Add, update, and delete menu items and categories
- Place orders for food items
- View order details

## Endpoints

### Menu Items

- **GET: Menu/List**: Retrieve all menu items
- **GET: Menu/Details/{id}**: Retrieve a specific menu item by its ID
- **POST: Menu/Create**: Add a new menu item
- **POST: Menu/Update/{id}**: Update an existing menu item
- **POST: Menu/Delete/{id}**: Delete a menu item by its ID

### Categories

- **GET /api/categories**: Retrieve all categories
- **GET /api/categories/{id}**: Retrieve a specific category by its ID
- **POST /api/categories**: Add a new category
- **PUT /api/categories/{id}**: Update an existing category
- **DELETE /api/categories/{id}**: Delete a category by its ID

### Orders

- **GET: /Orders/List**: Retrieve all orders
- **GET: /Orders/ListMenuItemsForOrder/{id}**: Retrieves the list of menu items for an order
- **GET: /Orders/OrdersForMenuItem/**: Retrieve list of orders for a menu item
- **POST: Orders/AddMenuItemToOrder/{orderid}/{menuid}**: Adds a menu item to the order
- **POST: Order/RemoveMenuItemFromOrder/{orderid}/{menuid}**: Removes a menu item from the order

