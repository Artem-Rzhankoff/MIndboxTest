SELECT name_product, name_category
FROM Product
         LEFT JOIN ProductCategory ON Product.product_id = ProductCategory.product_id
         LEFT JOIN Category ON Category.category_id = ProductCategory.category_id
