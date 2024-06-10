#!/bin/bash

# Adres bazowy API
BASE_URL="https://localhost:7184/api/Products"

# Testowanie GET all products
echo "GET all products"
curl -X GET "$BASE_URL" -H "Content-Type: application/json"
echo -e "\n"

# Testowanie GET product by id
echo "GET product by id"
PRODUCT_ID=1
curl -X GET "$BASE_URL/$PRODUCT_ID" -H "Content-Type: application/json"
echo -e "\n"

# Testowanie POST create product
echo "POST create product"
curl -X POST "$BASE_URL" -H "Content-Type: application/json" -d '{
  "name": "Nowy Produkt",
  "value": 123.45,
  "weight": 10,
  "expireDate": "2025-12-31",
  "typeOfDetention": 1,
  "typeOfProduct": 0,
  "shelfId": 1
}'
echo -e "\n"

# Testowanie PUT update product
echo "PUT update product"
UPDATED_PRODUCT_ID=1
curl -X PUT "$BASE_URL/$UPDATED_PRODUCT_ID" -H "Content-Type: application/json" -d '{
  "name": "Zaktualizowany Produkt",
  "value": 543.21,
  "weight": 2,
  "expireDate": "2025-12-31",
  "typeOfDetention": 1,
  "typeOfProduct": 1,
  "shelfId": 10
}'
echo -e "\n"

# Testowanie DELETE product
echo "DELETE product"
DELETE_PRODUCT_ID=1
curl -X DELETE "$BASE_URL/$DELETE_PRODUCT_ID" -H "Content-Type: application/json"
echo -e "\n"
