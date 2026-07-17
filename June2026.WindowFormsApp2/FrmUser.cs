using June2026.Database.AppDbContextModels;

namespace June2026.WinFormsApp2;

public partial class FrmUser : Form
{
    int EditUserId = 0;
    private readonly AppDbContext _db;
    public FrmUser()
    {   
        InitializeComponent();
        _db = new AppDbContext();
        ClearControl();
    }

    private void FrmUser_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        List<TblUser> lst = _db.TblUsers.ToList();

        int rno = 0;
        List<userDto> users = new List<userDto>();
        foreach (var item in lst)
        {
            rno++;
            userDto user = new userDto()
            {
                Rollno = rno,
                UserId = item.UserId,
                Username = item.Username,
                Password = item.Password,
            };
            
            users.Add(user);

        }

        dgvData.DataSource = users;
        ClearControl();
    }
    public class userDto
    {
        public int Rollno { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    private void btnCancle_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    private void ClearControl()
    {
        txtUsername.Clear();
        txtPassword.Clear();
        txtUsername.Focus();

    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if(EditUserId == 0)
        {
            _db.TblUsers.Add(new TblUser
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()

            });
            _db.SaveChanges();
        }

        else
        {
            TblUser? item = _db.TblUsers
                .Where(x => x.UserId == EditUserId)
                .FirstOrDefault();
            if (item is null) return;
            item.Username = txtUsername.Text.Trim();
            item.Password = txtPassword.Text.Trim();

            _db.SaveChanges();
        }

        EditUserId = 0;

        BindData();
    }

    private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1) return;

        if(e.ColumnIndex == 0)// Edit
        {
            int userId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[nameof(colUserId)].Value);
            TblUser? item = _db.TblUsers
                .Where(x => x.UserId == userId)
                .FirstOrDefault();

            if (item is null) return;

            txtUsername.Text = item.Username;
            txtPassword.Text = item.Password;
            EditUserId = item.UserId;
        }
        if (e.ColumnIndex == 1)  //Delete
        {
            DialogResult result = MessageBox.Show("Are you sure want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int userId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[nameof(colUserId)].Value);
                TblUser? item = _db.TblUsers
                    .Where(x => x.UserId == userId)
                    .FirstOrDefault();

                if (item is null)  return;

                _db.Remove(item);
                _db.SaveChanges();
                BindData();
            }

        }
    }
}
