use GameDB
go

create proc Top3StudiosByGamesCount
as
begin
	select top(3)c.* from Creators c join (select CreatorId,count(Id) gamesCount from Games group by CreatorId) res on c.Id = res.CreatorId
	order by res.gamesCount desc
end

create proc Top3StylesByGamesCount
as
begin
	select top(3)c.* from Styles c join (select StyleId,count(Id) gamesCount from Games group by StyleId) res on c.Id = res.StyleId
	order by res.gamesCount desc
end

create proc Top3StylesBySoldCopies
as
begin
	select top(3)c.* from Styles c join (select StyleId,sum(SoldCopies) gamesCount from Games group by StyleId) res on c.Id = res.StyleId
	order by res.gamesCount desc
end

create proc Top3SinglePlayers
as
begin
	select top(3)c.* from Games c join (select Name,sum(SoldCopies) gamesCount from Games where IsMultiplayer = 0 group by Name) res on c.Name = res.Name
	order by res.gamesCount desc
end

create proc Top3MultiPlayers
as
begin
	select top(3)c.* from Games c join (select Name,sum(SoldCopies) gamesCount from Games where IsMultiplayer = 1 group by Name) res on c.Name = res.Name
	order by res.gamesCount desc
end

create proc DeleteGamesBySales
@sales int
as
begin
	select * from Games where SoldCopies < @sales
	delete from Games where SoldCopies < @sales
end