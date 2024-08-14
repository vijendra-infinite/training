create database MiniProject_Railway 
use MiniProject_Railway


CREATE TABLE train (
    trainID int primary key,
    trainName varchar(50),
    Source varchar(50),
    Destination varchar(50),
    Status char(1) check (status IN (1,0))
);




-- trainbirthinfo table
CREATE TABLE TrainClassInfo (
    TrainClassID int  IDENTITY(1000,1) primary key,
    TrainID int,
    Class VARCHAR(50),
    TotalSeats int,
    AvailableSeats int,
    price DECIMAL(10, 2),
    FOREIGN KEY (TrainID) REFERENCES train(TrainID)
);

-------------------------------------------------------------------------------------------------------------------------
create table Booking (
    BookingID int identity(1,1)  primary key,
    TrainID int,
    UserName varchar(50),
    ClassType VARCHAR(50),
    Totaltickets int,
    BookingStatus CHAR(1) CHECK (BookingStatus IN ('Y', 'N')),
    payment_amount DECIMAL(10, 2),
    FOREIGN KEY (TrainID) REFERENCES train(TrainID),
    
);

select*from Booking	
--------------------------------------------------------------------

CREATE TABLE CancelTicket (
    CancelTicketID int identity(1,1) PRIMARY KEY,
    BookingID int,
    RefundAmount DECIMAL(10, 2),
    CancelDate DATETIME DEFAULT GETDATE(),
    foreign key (BookingID) references Booking(BookingID)
);

select * from CancelTicket

--------------------------------------------------------------------


--  admin table
CREATE TABLE Admin (
    AdminID int primary key,
    Username VARCHAR(50),
    Password VARCHAR(50),
	Phonenumber int 
);
select * from Admin


----------------------------------------------------------------------


--procedure for add a train

create or alter proc AddTrain
@TrainID int,
@TrainName VARCHAR(50),
@Source VARCHAR(50),
@Destination VARCHAR(50)
as
begin
    insert into Train (trainID,trainName, Source, Destination, Status)
    values(@TrainID ,@TrainName, @Source, @Destination, 'Y'); -- Assuming 'Y' indicates active status
end	


select*from train
select* from Booking

CREATE OR ALTER PROCEDURE AddTrainClassInfo
   @TrainID INT,
   @Class VARCHAR(50),
   @TotalSeats INT,
   @Price DECIMAL(10, 2)
AS
BEGIN
   -- Set AvailableSeats equal to TotalSeats
   DECLARE @AvailableSeats INT;
   SET @AvailableSeats = @TotalSeats;
   INSERT INTO TrainClassInfo (TrainID, Class, TotalSeats, AvailableSeats, Price)
   VALUES (@TrainID, @Class, @TotalSeats, @AvailableSeats, @Price);
END

-------------------------------------------------------------------------------------------------------------------
create or alter proc ModifyTrain
@TrainID INT,@TrainName varchar(50) ,@Source varchar(50),
 @Destination VARCHAR(50)
as
  begin
    update Train set TrainName = @TrainName,Source = @Source, Destination = @Destination where TrainID = @TrainID;
end

exec ModifyTrain
 @TrainID=1245,@TrainName='Sabarmati',@Source='Chennai',@Destination='delhi';

 ------------------------------------------------------------------------------------------------------------------
 -- Procedure to soft delete a train (set  status(N) to inactive)
create or alter proc SoftDeleteTrain @TrainID int
as
 begin
    update Train set Status = 0 where TrainID = @TrainID;
end
go

create or alter proc ChangeTrainStatus @TrainID int
as
begin
    update Train set 
	status = CASE 
                    WHEN Status = 1 THEN 0
                    WHEN Status = 0 THEN 1
                    ELSE Status
     end
    where TrainID = @TrainID;
end

----------------------------------------------------------------------------------------------

create or alter proc ShowAllTrain 
as 
begin
    select * from train;
END
exec ShowAllTrain;



Create or alter Proc InsertAdmin
   @AdminID int,
   @Username VARCHAR(50),
   @Phonenumber int ,
   @Password VARCHAR(50)
   
AS
BEGIN
   INSERT INTO Admin (AdminID, Username,Phonenumber, Password)
   VALUES (@AdminID, @Username,@Phonenumber, @Password);
END;

 --------------------------------------------------------------------------
 CREATE TABLE Users (
    UserID int primary key,
    Username VARCHAR(50),
    Password VARCHAR(50),
	Phonenumber int 
);
select*from Users

Create or alter Proc InsertUsers
   @UserID int,
   @Username VARCHAR(50),
   @Phonenumber int ,
   @Password VARCHAR(50)
   
AS
BEGIN


   INSERT INTO Users (UserID, Username,Phonenumber, Password)
   VALUES (@UserID, @Username,@Phonenumber, @Password);
END;


exec InsertUsers
@userid= 13 ,@Username= 'radha', @Phonenumber= 877787788,@Password= assa


-------------------------------------------------------------------------------------------------------

--procedure for see only active trains
---------------------
create or alter proc GetActiveTrains
as
BEGIN
    select * from Train where Status = 1;
END
----------------------------------procedure for birth details----------------------------
create or alter proc GetClassDetail
@TrainID INT
as
begin
    exec GetActiveTrains
	select*from TrainClassInfo WHERE TrainID=@TrainID;

end

exec GetClassDetail @trainid=61296



---------------------------------------------------------------------------------

-- Procedure for  the booking process-------------------
create or alter proc BookTrainTicket
    @UserName varchar(50),
    @TrainID int,
    @Class varchar(50),
    @TotalTickets int
as
begin
    -- Calculate booking amount 
    declare @Price decimal(10, 2);
    declare @BookingAmount decimal(10, 2);

    select @Price = price from TrainClassInfo where TrainID = @TrainID AND Class = @Class;
    set @BookingAmount = @Price * @TotalTickets;

    -- Check if the train and berth class  seats are available
    declare @AvailableSeats int;
    select  @AvailableSeats = AvailableSeats from TrainClassInfo where TrainID = @TrainID AND Class = @Class;

    if @AvailableSeats >= @TotalTickets
    begin
        -- Update available seats
        update TrainClassInfo set AvailableSeats = AvailableSeats - @TotalTickets
        where TrainID = @TrainID AND Class = @Class;

        -- Insert booking details
        insert into  Booking (TrainID,UserName, ClassType, Totaltickets, BookingStatus, payment_amount)
        values (@TrainID, @UserName, @Class, @TotalTickets, 'Y', @BookingAmount);
		end

END
-------------------------------------------------------------------------------------
Create or alter proc GetLastBookingID
as
begin

    SELECT MAX(BookingID) AS LastBookingID FROM Booking;
END


CREATE OR ALTER PROC Printticket
@BookingID int
as 
begin
    select*from Booking where BookingID=@BookingID;
end

-------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE GetTrainsByRoute
   @Source VARCHAR(50),
   @Destination VARCHAR(50)
AS
BEGIN
   -- Select trains where the source and destination match the provided values
   SELECT * FROM train
   WHERE Source = @Source AND Destination = @Destination AND Status = 1;
END

-------------------------------------------------------------------------------------------------------

Create or alter  proc CancelTicketData  
    @BookingID int  
AS  
BEGIN  
    declare @RefundAmount DECIMAL(10, 2);  
    declare @TotalAmount DECIMAL(10, 2);  
    declare @BookingStatus CHAR(1);  
    declare @TrainID INT;  
    declare @Class VARCHAR(50);  
    declare @TotalTickets int ;  
  
    -- Get booking details and berth class  
    select  
        @BookingStatus = BookingStatus,  
        @TotalAmount = payment_amount,  
        @TrainID = TrainID,  
        @Class = ClassType,  
        @TotalTickets = Totaltickets  
    from Booking  
    where BookingID = @BookingID;  
  
    if @BookingStatus = 'Y'  
    begin  
        -- Calculate refund amount (60%)  
        set @RefundAmount = @TotalAmount * 0.6;  
  
        -- Insert into CancelTicket table  
        INSERT INTO CancelTicket (BookingID, RefundAmount)  
        VALUES (@BookingID, @RefundAmount);  
  
        -- Update booking status to 'N' (Cancelled)  
        UPDATE Booking   
        SET BookingStatus = 'N'  
        WHERE BookingID = @BookingID;  
  
        -- Update available seats for the canceled tickets in the respective berth class  
        update TrainClassInfo  
        set AvailableSeats = AvailableSeats + @TotalTickets where TrainID = @TrainID AND Class = @Class;  
    END  
END
SP_helptext CancelTicketData
exec CancelTicketData @bookingID=1

-------------------------------------------------------------------------------------------------------
select*from train
select * from TrainClassInfo
select*from Booking
select * from CancelTicket