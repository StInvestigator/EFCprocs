use TournamentTopDB
go

create proc Top3ScorerCommnad
@command nvarchar(max)
as
begin
	select top(3)p.*
	from Players p join (select p.Id,count(p.Name) as Goals from Commands c join CommandPlayers cp on cp.CommandId=c.Id
		join GameGoals gl on gl.PlayerId = cp.PlayerId join Players p on p.Id = cp.PlayerId 
		where c.Name = @command group by p.Id) as res on res.Id = p.Id
	order by Goals desc
end


create proc Top3Scorer
as
begin
	select top(3)p.*
	from Players p join (select p.Name,count(p.Name) as Goals from Commands c join CommandPlayers cp on cp.CommandId=c.Id
		join GameGoals gl on gl.PlayerId = cp.PlayerId join Players p on p.Id = cp.PlayerId 
		group by p.Name) as res on res.Name = p.Name
	order by Goals desc
end

create proc Top3TeamScores 
as
begin
	select top(3)c.*
	from Commands c join 
	(select Name,sum(Goals) as Goals from (select c.Name,sum(g.Command1Goals) as Goals from Commands c join Games g on g.Command1Id = c.Id group by c.Name
	union all
	select c.Name,sum(g.Command2Goals) as Goals from Commands c join Games g on g.Command2Id = c.Id group by c.Name) as tmp group by Name) res on res.Name = c.Name
	order by Goals desc
end


create proc Top3TeamPasses
as
begin
	select top(3)c.*
	from Commands c join 
	(select Name,sum(Goals) as Goals from (select c.Name,sum(g.Command2Goals) as Goals from Commands c join Games g on g.Command1Id = c.Id group by c.Name
	union all
	select c.Name,sum(g.Command1Goals) as Goals from Commands c join Games g on g.Command2Id = c.Id group by c.Name) as tmp group by Name) res on res.Name = c.Name
	order by Goals
end

create proc Top3TeamByScore
as
begin
	select top(3)*
	from TournamentTop
	order by (Wins*3+Draws) desc
end

create proc Top3TeamByBadScore
as
begin
	select top(3)*
	from TournamentTop
	order by (Wins*3+Draws)
end
