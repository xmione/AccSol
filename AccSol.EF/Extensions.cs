using System.Data;

namespace AccSol.EF
{
    public static class IQueryableExtensions
    {
        public static DataTable ToDataTable<T>(this IQueryable<T> queryable)
        {
            DataTable dataTable = new DataTable();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }

            foreach (var item in queryable)
            {
                DataRow row = dataTable.NewRow();
                foreach (var propertyInfo in typeof(T).GetProperties())
                {
                    row[propertyInfo.Name] = propertyInfo.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        public static DataSet ToDataSet<T>(this IQueryable<T> queryable)
        {
            DataTable dataTable = new DataTable();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                dataTable.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }

            foreach (var item in queryable)
            {
                DataRow row = dataTable.NewRow();
                foreach (var propertyInfo in typeof(T).GetProperties())
                {
                    row[propertyInfo.Name] = propertyInfo.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }
    }

}
