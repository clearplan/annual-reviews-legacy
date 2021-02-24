use [CP.AnnualReview]
go
--select * 
--from tbl_AnnualReview_CompetencyTools_Responses as r
--inner join tbl_AnnualReview_ToolsoftheTrade as t on r.ToolID = t.ToolCategoryID
--where r.AnnualReviewID = 3;

--select * from tbl_AnnualReviews as rev
--join tbl_Resources as r on rev.ResourceID = r.ResourceID
--where r.FullName = 'Christy Springer';

--select * from tbl_AnnualReview_ToolsoftheTradeCategories as tc
--inner join tbl_AnnualReview_ToolsoftheTrade_Responses as tr on tc.ID = tr.ToolsoftheTradeID
--inner join tbl_AnnualReview_ToolsoftheTrade as tt on tr.ToolsoftheTradeID = tt.ToolCategoryID
--where tr.AnnualReviewID = 69;

select * from tbl_AnnualReview_CompetencyTools_Responses as tr
inner join tbl_AnnualReview_ToolsoftheTrade_Responses as tt on tr.ToolID = tt.ToolsoftheTradeID
where tr.AnnualReviewID = 69;
