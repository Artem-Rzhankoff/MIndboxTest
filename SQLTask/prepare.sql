CREATE TABLE Product(
                        product_id INT IDENTITY(1, 1) PRIMARY KEY,
                        name_product VARCHAR(256)
);
CREATE TABLE Category(
                         category_id INT IDENTITY(1, 1) PRIMARY KEY,
                         name_category VARCHAR(256)
);
CREATE TABLE ProductCategory(
                                id INT IDENTITY(1, 1) PRIMARY KEY,
                                product_id INT,
                                category_id INT,
                                FOREIGN KEY (product_id) REFERENCES Product(product_id),
                                FOREIGN KEY (category_id) REFERENCES Category(category_id)
);