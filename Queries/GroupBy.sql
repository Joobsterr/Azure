SELECT Username, CreationDate
  FROM [dbi408687].[dbo].[User]
  GROUP BY [Username], [CreationDate]
  ORDER BY [CreationDate] asc