﻿using HumorProteomics.Models;
using Microsoft.Data.SqlClient;

namespace HumorProteomics.Interface
{
    public interface IProteinData
    {
        List<ProteinData> GetAllProteinData(string sortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10);
        ProteinData GetProteinDataById(int id);
        ProteinData AddProteinData(ProteinData prod);
        ProteinData UpdateProteinData(ProteinData uprod);
        ProteinData Details(int id);
        void DeleteProteinData(int id);
    }
}
