
namespace FacturacionDigital_SIGECE.Helpers
{
    public class DocumentosHelper
    {
        public static List<(string NroDoc, string TipoDoc)> GetSelectedDocs(DataGridView dgv)
        {
            var documentos = new List<(string, string)>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                string docNum = row.Cells["NroDoc"].Value?.ToString() ?? string.Empty;
                string tipoDoc = row.Cells["TipoDoc"].Value?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(docNum) && !string.IsNullOrEmpty(tipoDoc))
                {
                    documentos.Add((docNum, tipoDoc));
                }
            }

            return documentos;
        }
    }
}
