-- Initialize TPV database schema and example data

CREATE TABLE IF NOT EXISTS users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    role VARCHAR(20) DEFAULT 'User',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS products (
    product_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10,2) NOT NULL DEFAULT 0,
    stock REAL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS tables (
    table_id SERIAL PRIMARY KEY,
    table_number INTEGER UNIQUE NOT NULL,
    seats INTEGER DEFAULT 4
);

CREATE TABLE IF NOT EXISTS reservations (
    reservation_id SERIAL PRIMARY KEY,
    table_id INTEGER REFERENCES tables(table_id),
    customer_name VARCHAR(100) NOT NULL,
    phone VARCHAR(20),
    reservation_datetime TIMESTAMP NOT NULL,
    meal_type VARCHAR(10) CHECK (meal_type IN ('Lunch','Dinner')),
    guests INTEGER DEFAULT 1,
    status VARCHAR(20) DEFAULT 'Active',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Admin user
INSERT INTO users (username, password_hash, role)
VALUES ('admin', 'Admin2025!', 'Admin');

-- Sample products
INSERT INTO products (name, description, price, stock)
VALUES 
('Beer', 'Local craft beer', 2.50, 100),
('Wine', 'House red wine', 3.00, 50),
('Bread', 'Freshly baked bread', 1.00, 30);

-- Sample tables
INSERT INTO tables (table_number, seats)
VALUES (1, 4), (2, 4), (3, 6), (4, 8);
