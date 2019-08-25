# Run once, results in data duplication otherwise.
from pymongo import MongoClient
import os
import json

# Establishing database connection.
client = MongoClient()
db = client['ZetsubouGacha']
servants_collection = db['Servants']

# Loading the JSON data.
data_path = '..\TestData\servantDataUpdate2.json'
servant_data = []
with open(os.path.join(os.path.dirname(__file__), data_path), 'r') as data:
    servant_data = json.load(data)

# Pushing to the database.
servants_collection.insert_many(servant_data)
