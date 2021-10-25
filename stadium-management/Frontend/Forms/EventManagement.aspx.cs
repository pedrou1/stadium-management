using stadium_management.CrossCuttingConcerns.Entities;
using stadium_management.CrossCuttingConcerns.InMethods;
using stadium_management.CrossCuttingConcerns.OutMethods;
using stadium_management.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stadium_management.Frontend.Forms
{
    public partial class EventManagement : BaseAdministrator
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                loadDdlEventTypes();
                btnCancel.Visible = false;
                btnUpdate.Visible = false;
                divId.Visible = false;
                loadEventsData();
            }
        }

        protected virtual void loadDdlEventTypes()
        {
            GetEventTypesOut outGetEventType = Facade.GetEventTypes();
            if (outGetEventType.OperationResult == OperationResult.Success)
            {
                foreach (EventType eventType in outGetEventType.EventTypes)
                {
                    ListItem ddlEventTypeItem = new ListItem(eventType.Name, eventType.Id.ToString());
                    ddlEventTypes.Items.Add(ddlEventTypeItem);
                }
            }
        }

        protected virtual void loadEventsData()
        {
            GetEventsOut outGetEventsOut = Facade.GetEvents(new GetEventsIn { PageIndex = 0, PageSize = grdEvents.PageSize });
            this.grdEvents.DataSource = outGetEventsOut.Events;
            this.grdEvents.DataBind();
            DatabindRepeater(0, grdEvents.PageSize, outGetEventsOut.TotalRows);
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            grdEvents.PageIndex = pageIndex;
            GetEventsOut outGetEventsOut = Facade.GetEvents(new GetEventsIn { PageIndex = pageIndex, PageSize = grdEvents.PageSize });
            grdEvents.DataSource = outGetEventsOut.Events;
            grdEvents.DataBind();
            DatabindRepeater(pageIndex, grdEvents.PageSize, outGetEventsOut.TotalRows);
        }

        private void DatabindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPages = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPages += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }
            repeaterPaging.DataSource = pages;
            repeaterPaging.DataBind();
        }

        public DateTime ConvertJsDate(string jsDate)
        {
            string formatString = "ddd-MMM-d-yyyy HH:mm:ss";

            var gmtIndex = jsDate.IndexOf(" GMT");
            if (gmtIndex > -1)
            {
                jsDate = jsDate.Remove(gmtIndex);
                int i = 0;
                jsDate = Regex.Replace(jsDate, @" ", m => {
                    i++;
                    if (i < 4)
                        return "-";
                    else
                        return " ";
                });

                return DateTime.ParseExact(jsDate, formatString, CultureInfo.InvariantCulture);
            }
            return DateTime.Parse(jsDate);
        }

 

        protected void AddEvent(object sender, EventArgs e)
        {
            lblMessageResult.Visible = false;
            lblImageMessage.Visible = false;
            var date = ConvertJsDate(txtDateTimePicker.Text);

            Event Event = new Event
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Stage = new Stage { Id = 1 },
                Requirements = txtRequirements.Text,
                Image = Path.GetFileName(fuImage.FileName),
                StartTime = date,
                EndTime = date,
                SeatsAvailableStandard = 200,
                SeatsAvailablePlus = 100,
                EventType = new EventType
                {
                    Id = int.Parse(ddlEventTypes.SelectedItem.Value),
                    Name = ddlEventTypes.SelectedItem.Text
                },
                BasePrice = int.Parse(txtPrice.Text)
            };

            if (!fuImage.HasFile)
            {
                lblImageMessage.Text = "La imagen es obligatoria.";
                lblImageMessage.Visible = true;
                return;
            }

            if (Path.GetExtension(fuImage.FileName) != ".jpg" && Path.GetExtension(fuImage.FileName) != ".JPG")
            {
                lblImageMessage.Text = "Solo se acepta extención jpg.";
                lblImageMessage.Visible = true;
                return;
            }

            string pathImg = Path.Combine(Server.MapPath("~/ImagesUpload/"), fuImage.FileName);

            if (!File.Exists(pathImg))
            {
                try
                {
                    AddEventOut outAddEvent = Facade.AddEvent(Event);
                    if (outAddEvent.OperationResult == OperationResult.Success)
                    {
                        fuImage.SaveAs(pathImg);
                        loadEventsData();
                        ClearFields();
                        lblMessageResult.Text = "Evento registrado con éxito.";
                        lblMessageResult.Visible = true;
                    }
                    else
                    {
                        lblMessageResult.Text = "Ocurrio un error al ingresar el Evento.";
                        lblMessageResult.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                lblImageMessage.Text = "Nombre de la imagen ya existe.";
                lblImageMessage.Visible = true;
            }
        }

        protected void ClearEvent(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void ClearFields()
        {
            this.txtName.Text = string.Empty;
            this.txtPrice.Text = string.Empty;
            this.txtRequirements.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.fuImage.Dispose();
            this.lblImageMessage.Visible = false;
            this.divId.Visible = false;
            this.imgprw.ImageUrl = "~/Images/previewImage.png";
            this.lblMessageResult.Text = "";
        }

        protected void grdEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessageResult.Visible = false;
            lblImageMessage.Visible = false;
            if (e.CommandName == "DeleteEvent")
            {
                Event Event = new Event
                {
                    Id = Convert.ToInt32(e.CommandArgument),
                    EventType = new EventType()
                };
                try
                {
                    DeleteEventOut outDeleteEvent = Facade.DeleteEvent(Event);
                    if (outDeleteEvent.OperationResult == OperationResult.Success)
                    {
                        loadEventsData();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (e.CommandName == "UpdateEvent")
            {
                Event Event = new Event
                {
                    Id = Convert.ToInt32(e.CommandArgument),
                    EventType = new EventType()
                };
                try
                {
                    GetEventByIdOut outGetEventById = Facade.GetEventById(Event);
                    if (outGetEventById.OperationResult == OperationResult.Success)
                    {
                        loadEventToUpdate(outGetEventById.Event);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected virtual void loadEventToUpdate(Event Event)
        {
            txtId.Text = Event.Id.ToString();
            txtName.Text = Event.Name;
            txtPrice.Text = Event.BasePrice.ToString();
            txtRequirements.Text = Event.Requirements;
            txtDescription.Text = Event.Description.ToString();
            ddlEventTypes.SelectedValue = Event.EventType.Id.ToString();
            imgprw.ImageUrl = "~/ImagesUpload/" + Event.Image;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnClear.Visible = false;
            divId.Visible = true;
        }

        protected void CancelEvent(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
            btnClear.Visible = true;
            ClearFields();
        }

        protected void UpdateEvent(object sender, EventArgs e)
        {
            lblMessageResult.Visible = false;
            lblImageMessage.Visible = false;

            if (fuImage.HasFile)
            {
                if (Path.GetExtension(fuImage.FileName) != ".jpg")
                {
                    lblImageMessage.Text = "Solo se acepta extención jpg.";
                    lblImageMessage.Visible = true;
                    return;
                }

                string pathImg = Path.Combine(Server.MapPath("~/ImagesUpload/"), fuImage.FileName);
                if (File.Exists(pathImg))
                {
                    lblImageMessage.Text = "El Nombre de la imagen ya existe.";
                    lblImageMessage.Visible = true;
                    return;
                }
            }
            else if (imgprw.ImageUrl == "~/Images/previewImage.png")
            {
                lblImageMessage.Text = "La imagen es obligatoria.";
                lblImageMessage.Visible = true;
                return;
            }

            try
            {
                Event Event = new Event
                {
                    Id = int.Parse(txtId.Text),
                    BasePrice = int.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    Name = txtName.Text,
                    Requirements = txtRequirements.Text,
                    EventType = new EventType
                    {
                        Id = int.Parse(ddlEventTypes.SelectedItem.Value),
                        Name = ddlEventTypes.SelectedItem.Text
                    }
                };

                if (fuImage.HasFile)
                {
                    Event.Image = Path.GetFileName(fuImage.FileName);
                }
                else
                {
                    Event.Image = Path.GetFileName(imgprw.ImageUrl);
                }
                string img = Path.Combine(Server.MapPath("~/ImagesUpload/"), Event.Image);

                UpdateEventOut outUpdateEvent = Facade.UpdateEvent(Event);
                if (outUpdateEvent.OperationResult == OperationResult.Success)
                {
                    if (fuImage.HasFile)
                    {
                        fuImage.SaveAs(img);
                    }
                    loadEventsData();
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    btnClear.Visible = true;
                    ClearFields();
                    lblMessageResult.Text = "Evento modificado con éxito.";
                    lblMessageResult.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    btnClear.Visible = true;
                    ClearFields();
                    lblMessageResult.Text = "Ocurrio un error al modificar el Evento.";
                    lblMessageResult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}