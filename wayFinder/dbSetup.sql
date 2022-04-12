CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS destinations(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name VARCHAR(255) NOT NULL COMMENT 'Destination Name',
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS reservations(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  title TEXT NOT NULL,
  type TEXT NOT NULL,
  confirmation TEXT NOT NULL,
  address TEXT NOT NULL,
  date DATE NOT NULL,
  notes TEXT NOT NULL,
  cost INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  destinationId INT NOT NULL,
  FOREIGN KEY (destinationId) REFERENCES destinations(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS attendees(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  destinationId INT NOT NULL,
  FOREIGN KEY (destinationId) REFERENCES destinations(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';