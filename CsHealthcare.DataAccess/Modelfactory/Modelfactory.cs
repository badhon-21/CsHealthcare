using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsHealthcare.DataAccess.Dialysis;
using CsHealthcare.DataAccess.Doctor;
using CsHealthcare.DataAccess.Entities.Doctor;
using CsHealthcare.DataAccess.Entities.Hospital;
using CsHealthcare.DataAccess.Entities.Operation;
using CsHealthcare.DataAccess.Entities.Patient;
using CsHealthcare.DataAccess.Entities.User;
using CsHealthcare.DataAccess.Entity;
using CsHealthcare.DataAccess.Entity.Accounts;
using CsHealthcare.DataAccess.Entity.Ambulance;
using CsHealthcare.DataAccess.Entity.Cabin;
using CsHealthcare.DataAccess.Entity.Canteen;
using CsHealthcare.DataAccess.Entity.Diagnostic;
using CsHealthcare.DataAccess.Entity.EmployeeLoan;
using CsHealthcare.DataAccess.Entity.Hospital;
using CsHealthcare.DataAccess.Entity.HumanResource;
using CsHealthcare.DataAccess.Entity.LabItem;
using CsHealthcare.DataAccess.Entity.LeaveManagement;
using CsHealthcare.DataAccess.Entity.Master;
using CsHealthcare.DataAccess.Entity.MedicineCorner;
using CsHealthcare.DataAccess.Entity.MicrobiologyTest;
using CsHealthcare.DataAccess.Entity.Packages;
using CsHealthcare.DataAccess.Entity.Patient;
using CsHealthcare.DataAccess.Entity.Physiotherapy;
using CsHealthcare.DataAccess.Entity.Stock;
using CsHealthcare.DataAccess.Entity.Store;
using CsHealthcare.DataAccess.HumanResource;
using CsHealthcare.DataAccess.Migrations;
using CsHealthcare.DataAccess.ViewModel.Dialysis;
using CsHealthcare.ViewModel;
using CsHealthcare.ViewModel.Accounts;
using CsHealthcare.ViewModel.Ambulance;
using CsHealthcare.ViewModel.Cabin;
using CsHealthcare.ViewModel.Canteen;
using CsHealthcare.ViewModel.Diagnostic;
using CsHealthcare.ViewModel.Disease;
using CsHealthcare.ViewModel.Doctor;
using CsHealthcare.ViewModel.EmployeeLoan;
using CsHealthcare.ViewModel.HumanResource;
using CsHealthcare.ViewModel.Hospital;
using CsHealthcare.ViewModel.LabItem;
using CsHealthcare.ViewModel.LeaveManagement;
using CsHealthcare.ViewModel.Master;
using CsHealthcare.ViewModel.MedicineCorner;
using CsHealthcare.ViewModel.MicrobiologyTest;
using CsHealthcare.ViewModel.Operation;
using CsHealthcare.ViewModel.Packages;
using CsHealthcare.ViewModel.Patient;
using CsHealthcare.ViewModel.Physiotherapy;
using CsHealthcare.ViewModel.Stock;
using CsHealthcare.ViewModel.Store;
using CsHealthcare.ViewModel.User;
using WebGrease.Css.Extensions;

namespace CsHealthcare.DataAccess.Modelfactory
{
    public class Modelfactory : IModelfactory
    {


        public InPatientDischargeDueCollection Create(InPatientDischargeDueCollectionModel obj)
        {
            return new InPatientDischargeDueCollection
            {
                Id = obj.Id,
               CollectedDue = obj.CollectedDue,
               PatientCode = obj.PatientCode,
               VoucherNo = obj.VoucherNo,
               CollectionDate = obj.CollectionDate,
               CreatedBy = obj.CreatedBy,
               DueAmount = obj.DueAmount,
               PreviousDue = obj.PreviousDue,
               PreviousGivenAmount = obj.PreviousGivenAmount



            };
        }

        public InPatientDischargeDueCollectionModel Create(InPatientDischargeDueCollection obj)
        {
            return new InPatientDischargeDueCollectionModel
            {
                Id = obj.Id,
                CollectedDue = obj.CollectedDue,
                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                CollectionDate = obj.CollectionDate,
                CreatedBy = obj.CreatedBy,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                PreviousGivenAmount = obj.PreviousGivenAmount


            };
        }


        public MerketingBy Create(MerketingByModel obj)
        {
            return new MerketingBy
            {
                Id = obj.Id,
                Name = obj.Name,
                Designation = obj.Designation,



            };
        }

        public MerketingByModel Create(MerketingBy obj)
        {
            return new MerketingByModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Designation = obj.Designation,



            };
        }
        public CabinTransferBack Create(CabinTransferBackModel obj)
        {
            return new CabinTransferBack
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                AdmissionNo = obj.AdmissionNo,
                CabinId = obj.CabinId,
                CabinAmount = obj.CabinAmount,
                CabinName = obj.CabinName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                NoOfDays = obj.NoOfDays,
                TotalAmount = obj.TotalAmount,
                TransferBackDate = obj.TransferBackDate,
                TransferDate = obj.TransferDate,
                TransferedCabinId = obj.TransferedCabinId,
                TransferedCabinName = obj.TransferedCabinName

            };
        }

        public CabinTransferBackModel Create(CabinTransferBack obj)
        {
            return new CabinTransferBackModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                AdmissionNo = obj.AdmissionNo,
                CabinId = obj.CabinId,
                CabinAmount = obj.CabinAmount,
                CabinName = obj.CabinName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                NoOfDays = obj.NoOfDays,
                TotalAmount = obj.TotalAmount,
                TransferBackDate = obj.TransferBackDate,
                TransferDate = obj.TransferDate,
                TransferedCabinId = obj.TransferedCabinId,
                TransferedCabinName = obj.TransferedCabinName
            };
        }

        public CabinToCabinTransfer Create(CabinToCabinTransferModel obj)
        {
            return new CabinToCabinTransfer
            {
                Id = obj.Id,
                AdmissionNo = obj.AdmissionNo,
                CabinAmount = obj.CabinAmount,
                CabinName = obj.CabinName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                TransferDate = obj.TransferDate,
                TransferedCabinId = obj.TransferedCabinId,
                TransferedCabinName = obj.TransferedCabinName,
                CabinId = obj.CabinId,
                PatientCode = obj.PatientCode

            };
        }

        public CabinToCabinTransferModel Create(CabinToCabinTransfer obj)
        {
            return new CabinToCabinTransferModel
            {
                Id = obj.Id,
                AdmissionNo = obj.AdmissionNo,
                CabinAmount = obj.CabinAmount,
                CabinName = obj.CabinName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                TransferDate = obj.TransferDate,
                TransferedCabinId = obj.TransferedCabinId,
                TransferedCabinName = obj.TransferedCabinName,
                CabinId = obj.CabinId,
                PatientCode = obj.PatientCode

            };
        }





        public PatientAppointmentDialysis Create(PatientAppointmentDialysisModel obj)
        {
            return new PatientAppointmentDialysis
            {
                Id = obj.Id,
                Date = obj.Date,
                PatientId = obj.PatientId,
                Time = obj.Time,
                PatientType = obj.PatientType,
                AppointmentType = obj.AppointmentType,

                MobileNo = obj.MobileNo,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public PatientAppointmentDialysisModel Create(PatientAppointmentDialysis obj)
        {
            return new PatientAppointmentDialysisModel
            {
                Id = obj.Id,
                Date = obj.Date,
                PatientId = obj.PatientId,
                PatientName = obj.PatientName,
                Time = obj.Time,
                PatientType = obj.PatientType,
                AppointmentType = obj.AppointmentType,

                MobileNo = obj.MobileNo,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public PatientDueCollection Create(PatientDueCollectionModel obj)
        {
            return new PatientDueCollection
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue

            };
        }

        public PatientDueCollectionModel Create(PatientDueCollection obj)
        {
            return new PatientDueCollectionModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                PatientId = obj.PatientId,
                VoucherNo = obj.VoucherNo,
                CreatedBy = obj.CreatedBy,
                PreviousGivenAmount = obj.PreviousGivenAmount,
                TestId = obj.TestId,
            };
        }

        public AssistantDoctor Create(AssistantDoctorModel obj)
        {
            return new AssistantDoctor
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorName,
                OperationTheatreId = obj.OperationTheatreId,
                SurgeonAmount = obj.SurgeonAmount

            };
        }

        public AssistantDoctorModel Create(AssistantDoctor obj)
        {
            return new AssistantDoctorModel
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorName,
                OperationTheatreId = obj.OperationTheatreId,
                SurgeonAmount = obj.SurgeonAmount
            };
        }
        public Anesthesia Create(AnesthesiaModel obj)
        {
            return new Anesthesia
            {
                Id = obj.Id,
                OperationTheatreId = obj.OperationTheatreId,
                AnesdthesiaName = obj.AnesdthesiaName,
                AnesthesiaPrice = obj.AnesthesiaPrice,


            };
        }

        public AnesthesiaModel Create(Anesthesia obj)
        {
            return new AnesthesiaModel
            {
                Id = obj.Id,

                OperationTheatreId = obj.OperationTheatreId,
                AnesdthesiaName = obj.AnesdthesiaName,
                AnesthesiaPrice = obj.AnesthesiaPrice,
            };
        }

        public SurgeonName Create(SurgeonNameModel obj)
        {
            return new SurgeonName
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorName,
                OperationTheatreId = obj.OperationTheatreId,
                SurgeonAmount = obj.SurgeonAmount

            };
        }

        public SurgeonNameModel Create(SurgeonName obj)
        {
            return new SurgeonNameModel
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorName,
                OperationTheatreId = obj.OperationTheatreId,
                SurgeonAmount = obj.SurgeonAmount
            };
        }


        public PurposeOnOT Create(PurposeOnOTModel obj)
        {
            return new PurposeOnOT
            {
                Id = obj.Id,
                OperationTheatreId = obj.OperationTheatreId,
                PurposeId = obj.PurposeId,
                PurposeAmount = obj.PurposeAmount

            };
        }

        public PurposeOnOTModel Create(PurposeOnOT obj)
        {
            return new PurposeOnOTModel
            {
                Id = obj.Id,
                OperationTheatreId = obj.OperationTheatreId,
                PurposeId = obj.PurposeId,
                PurposeAmount = obj.PurposeAmount
            };
        }


        public OperationTheatre Create(OperationTheatreModel obj)
        {
            return new OperationTheatre
            {
                Id = obj.Id,
                OperationDate = obj.OperationDate,
                OperationName = obj.OperationName,
                OperationStartTime = obj.OperationStartTime,
                OperationEndTime = obj.OperationEndTime,
                PatientCode = obj.PatientCode,
                OperationType = obj.OperationType,
                TotalAmount = obj.TotalAmount,
            };
        }

        public OperationTheatreModel Create(OperationTheatre obj)
        {
            return new OperationTheatreModel
            {
                Id = obj.Id,
                OperationDate = obj.OperationDate,
                OperationName = obj.OperationName,
                OperationStartTime = obj.OperationStartTime,
                OperationEndTime = obj.OperationEndTime,
                PatientCode = obj.PatientCode,
                OperationType = obj.OperationType,
                TotalAmount = obj.TotalAmount,
                PurposeOnOTModels = obj.PurposeOnOT.Select(Create).ToList(),
                SurgeonNameModels = obj.SurgeonName.Select(Create).ToList()

            };
        }


        public PatientTestReportAttatchment Create(PatientTestReportAttatchmentModel obj)
        {
            return new PatientTestReportAttatchment
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,

                FileName = obj.FileName,
                AttatchmentDate = obj.AttatchmentDate,
                PatientId = obj.PatientId,
                TestDate = obj.TestDate,
                TestName = obj.TestName

            };
        }

        public PatientTestReportAttatchmentModel Create(PatientTestReportAttatchment obj)
        {
            return new PatientTestReportAttatchmentModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,

                FileName = obj.FileName,
                AttatchmentDate = obj.AttatchmentDate,
                PatientId = obj.PatientId,
                TestDate = obj.TestDate,
                TestName = obj.TestName
            };
        }
        public PrescriptionAttatchment Create(PrescriptionAttatchmentModel obj)
        {
            return new PrescriptionAttatchment
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                DoctorId = obj.DoctorId,
                Date = obj.Date,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                FileName = obj.FileName

            };
        }

        public PrescriptionAttatchmentModel Create(PrescriptionAttatchment obj)
        {
            return new PrescriptionAttatchmentModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                DoctorId = obj.DoctorId,
                Date = obj.Date,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                FileName = obj.FileName

            };
        }


        public InPatientDischargeSummary Create(InPatientDischargeSummaryModel obj)
        {
            return new InPatientDischargeSummary
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                PatientName = obj.PatientName,
                AdmissionDate = obj.AdmissionDate,
                AttendingPhysician = obj.AttendingPhysician,
                BabyNote = obj.BabyNote,
                ClinicalFindings = obj.ClinicalFindings,
                ConditionOnDischarge = obj.ConditionOnDischarge,
                ConsultationDictician = obj.ConsultationDictician,
                ConsultineuningRx = obj.ConsultineuningRx,
                ConsultingPhysician = obj.ConsultingPhysician,
                CreatedDate = obj.CreatedDate,
                DischargeBy = obj.DischargeBy,
                DischargeDate = obj.DischargeDate,
                FinalDiadiagnosis = obj.FinalDiadiagnosis,
                FollowUp = obj.FollowUp,
                IndicationOfOperation = obj.IndicationOfOperation,
                Instruction = obj.Instruction,
                NameOfAnesthesia = obj.NameOfAnesthesia,
                NameOfOperation = obj.NameOfOperation,
                OperationDate = obj.OperationDate,
                OperationTime = obj.OperationTime,
                RefferingPhysician = obj.RefferingPhysician,
                TreatmentDuringHospital = obj.TreatmentDuringHospital,
                InvestigationDuringAdmission = obj.InvestigationDuringAdmission

            };
        }

        public InPatientDischargeSummaryModel Create(InPatientDischargeSummary obj)
        {
            return new InPatientDischargeSummaryModel
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,

                PatientName = obj.PatientName,
                AdmissionDate = obj.AdmissionDate,
                AttendingPhysician = obj.AttendingPhysician,
                BabyNote = obj.BabyNote,
                ClinicalFindings = obj.ClinicalFindings,
                ConditionOnDischarge = obj.ConditionOnDischarge,
                ConsultationDictician = obj.ConsultationDictician,
                ConsultineuningRx = obj.ConsultineuningRx,
                ConsultingPhysician = obj.ConsultingPhysician,
                CreatedDate = obj.CreatedDate,
                DischargeBy = obj.DischargeBy,
                DischargeDate = obj.DischargeDate,
                FinalDiadiagnosis = obj.FinalDiadiagnosis,
                FollowUp = obj.FollowUp,
                IndicationOfOperation = obj.IndicationOfOperation,
                Instruction = obj.Instruction,
                NameOfAnesthesia = obj.NameOfAnesthesia,
                NameOfOperation = obj.NameOfOperation,
                OperationDate = obj.OperationDate,
                OperationTime = obj.OperationTime,
                RefferingPhysician = obj.RefferingPhysician,
                TreatmentDuringHospital = obj.TreatmentDuringHospital,
                InvestigationDuringAdmission = obj.InvestigationDuringAdmission
            };
        }
        public ICURent Create(ICURentModel obj)
        {
            return new ICURent
            {
                Id = obj.Id,
                ICUBedsId = obj.ICUBedsId,
                ICUId = obj.ICUId,
                PatientCode = obj.PatientCode,
                Rate = obj.Rate,
                TotalPrice = obj.TotalPrice,
                Status = obj.Status,
                RentDate = obj.RentDate

            };
        }

        public ICURentModel Create(ICURent obj)
        {
            return new ICURentModel
            {
                Id = obj.Id,
                ICUBedsId = obj.ICUBedsId,
                ICUId = obj.ICUId,
                PatientCode = obj.PatientCode,
                Rate = obj.Rate,
                TotalPrice = obj.TotalPrice,
                Status = obj.Status,
                RentDate = obj.RentDate,
                ICUBedName = obj.ICUBeds.Name,
                ICUName = obj.ICU.Name

            };
        }

        public ICUBeds Create(ICUBedsModel obj)
        {
            return new ICUBeds
            {
                Id = obj.Id,
                Name = obj.Name,
                PriceByDay = obj.PriceByDay,
                PriceByHour = obj.PriceByHour,
                IcuId = obj.IcuId


            };
        }

        public ICUBedsModel Create(ICUBeds obj)
        {
            return new ICUBedsModel
            {
                Id = obj.Id,
                Name = obj.Name,
                PriceByDay = obj.PriceByDay,
                PriceByHour = obj.PriceByHour,
                IcuId = obj.IcuId,
                IcuName = obj.Icu.Name

            };
        }



        public ICU Create(ICUModel obj)
        {
            return new ICU
            {
                Id = obj.Id,
                Name = obj.Name,
                //PriceByDay = obj.PriceByDay,
                //PriceByHour = obj.PriceByHour


            };
        }

        public ICUModel Create(ICU obj)
        {
            return new ICUModel
            {
                Id = obj.Id,
                Name = obj.Name,
                //PriceByDay = obj.PriceByDay,
                //PriceByHour = obj.PriceByHour

                ICUBedsModels = obj.ICUBeds.Select(Create).ToList()
            };
        }


        public InPatientTransfer Create(InPatientTransferModel obj)
        {
            return new InPatientTransfer
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CabinName = obj.CabinName,
                ICUName = obj.ICUName,
                ICUPrice = obj.ICUPrice,
                ICUType = obj.ICUType,
                Status = obj.Status,
                TransferDate = obj.TransferDate,
                BedName = obj.BedName,
                BedPrice = obj.BedPrice,
                BedType = obj.BedType


            };
        }

        public InPatientTransferModel Create(InPatientTransfer obj)
        {
            return new InPatientTransferModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CabinName = obj.CabinName,
                ICUName = obj.ICUName,
                ICUPrice = obj.ICUPrice,
                ICUType = obj.ICUType,
                Status = obj.Status,
                TransferDate = obj.TransferDate,
                BedName = obj.BedName,
                BedPrice = obj.BedPrice,
                BedType = obj.BedType

            };
        }

        public InPatientTransferBack Create(InPatientTransferBackModel obj)
        {
            return new InPatientTransferBack
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CabinName = obj.CabinName,
                ICUName = obj.ICUName,
                ICUPrice = obj.ICUPrice,
                ICUType = obj.ICUType,
                Status = obj.Status,
                TransferDate = obj.TransferDate,
                BackDate = obj.BackDate,
                NoOfDays = obj.NoOfDays,
                NoOfHours = obj.NoOfHours,
                BedName = obj.BedName,
                BedPrice = obj.BedPrice,
                BedType = obj.BedType


            };
        }

        public InPatientTransferBackModel Create(InPatientTransferBack obj)
        {
            return new InPatientTransferBackModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CabinName = obj.CabinName,
                ICUName = obj.ICUName,
                ICUPrice = obj.ICUPrice,
                ICUType = obj.ICUType,
                Status = obj.Status,
                TransferDate = obj.TransferDate,
                BackDate = obj.BackDate,
                NoOfDays = obj.NoOfDays,
                NoOfHours = obj.NoOfHours,
                BedName = obj.BedName,
                BedPrice = obj.BedPrice,
                BedType = obj.BedType

            };
        }

        public CheckInCheckOut Create(CheckInCheckOutModel obj)
        {
            return new CheckInCheckOut
            {
                Id = obj.Id,
                EmployeeId = obj.EmployeeId,
                CheckInDateTime = obj.CheckInDateTime,
                CheckOutDateTime = obj.CheckOutDateTime,
                Remarks = obj.Remarks,
                TotalHours = obj.TotalHours
            };
        }

        public CheckInCheckOutModel Create(CheckInCheckOut obj)
        {
            return new CheckInCheckOutModel
            {
                //Id = obj.Id,
                EmployeeId = obj.EmployeeId,
                //EmployeeName = obj.EmployeeInfo.FirstName + " " + obj.EmployeeInfo.LastName,
                CheckInDateTime = obj.CheckInDateTime,
                CheckOutDateTime = obj.CheckOutDateTime,
                Remarks = obj.Remarks,
                TotalHours = obj.TotalHours
            };
        }



        public PackageForCheckUp Create(PackageForCheckUpModel obj)
        {
            return new PackageForCheckUp
            {
                Id = obj.Id,
                Name = obj.Name,
                Date = obj.Date,
                Price = obj.Price
            };
        }


        public PackageForCheckUpModel Create(PackageForCheckUp obj)
        {
            return new PackageForCheckUpModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Date = obj.Date,
                Price = obj.Price,
                PackageForCheckupDetailsModels = obj.PackageForCheckupDetails.Select(Create).ToList()
            };
        }


        public PackageForCheckupDetails Create(PackageForCheckupDetailsModel obj)
        {
            return new PackageForCheckupDetails
            {
                Id = obj.Id,
                Name = obj.Name,
                PackageForCheckUpId = obj.PackageForCheckUpId,

            };
        }


        public PackageForCheckupDetailsModel Create(PackageForCheckupDetails obj)
        {
            return new PackageForCheckupDetailsModel
            {
                Id = obj.Id,
                Name = obj.Name,
                PackageForCheckUpId = obj.PackageForCheckUpId,

            };
        }

        public OPDTherapy Create(OPDTherapyModel obj)
        {
            return new OPDTherapy
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                OccupationId = obj.OccupationId,
                EducationId = obj.EducationId,
                PatientName = obj.PatientName,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                Sex = obj.Sex,
                ReferanceName = obj.ReferanceName,
                Address = obj.Address,
                Age = obj.Age,
                BloodGroup = obj.BloodGroup,
                VoucherNo = obj.VoucherNo,
                GivenAmount = obj.GivenAmount,

                TotalAmount = obj.TotalAmount,
                TotalPrice = obj.TotalPrice,
                MarketingBy = obj.MarketingBy,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                DeuAmount = obj.DeuAmount,
                Remarks = obj.Remarks

            };
        }

        public OPDTherapyModel Create(OPDTherapy obj)
        {
            return new OPDTherapyModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                OccupationId = obj.OccupationId,
                EducationId = obj.EducationId,
                PatientName = obj.PatientName,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                Sex = obj.Sex,
                ReferanceName = obj.ReferanceName,
                Address = obj.Address,
                Age = obj.Age,
                BloodGroup = obj.BloodGroup,
                VoucherNo = obj.VoucherNo,
                GivenAmount = obj.GivenAmount,
                CreatedDate = obj.CreatedDate,
                TotalAmount = obj.TotalAmount,

                TotalPrice = obj.TotalPrice,
                MarketingBy = obj.MarketingBy,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,

                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Remarks = obj.Remarks,
                DeuAmount = obj.DeuAmount,
                OpdTherapyDetailsModels = obj.OpdTherapyDetails.Select(Create).ToList(),



            };
        }

        public OpdTherapyDetails Create(OpdTherapyDetailsModel obj)
        {
            return new OpdTherapyDetails
            {
                Id = obj.Id,
                OPDTherapyId = obj.OPDTherapyId,
                PhysiotherapyId = obj.PhysiotherapyId,
                TherapyPrice = obj.TherapyPrice,
                Quantity = obj.Quantity,
                Discount = obj.Discount,
                SubTotal = obj.SubTotal


            };
        }

        public OpdTherapyDetailsModel Create(OpdTherapyDetails obj)
        {
            return new OpdTherapyDetailsModel
            {
                Id = obj.Id,
                OPDTherapyId = obj.OPDTherapyId,
                PhysiotherapyId = obj.PhysiotherapyId,
                TherapyPrice = obj.TherapyPrice,
                PhysiotherapyName = obj.Physiotherapy.Name,
                Quantity = obj.Quantity,
                Discount = obj.Discount,
                SubTotal = obj.SubTotal


            };
        }



        public Physiotherapy Create(PhysiotherapyModel obj)
        {
            return new Physiotherapy
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                Category = obj.Category,
                Remarks = obj.Remarks


            };
        }

        public PhysiotherapyModel Create(Physiotherapy obj)
        {
            return new PhysiotherapyModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                Category = obj.Category,
                Remarks = obj.Remarks


            };
        }
        public OpdTherapyDueCollection Create(OpdTherapyDueCollectionModel obj)
        {
            return new OpdTherapyDueCollection
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                VoucherNo = obj.VoucherNo,
                //PatientId = obj.PatientId,
                PreviousGivenAmount = obj.PreviousGivenAmount,
                TherapyId = obj.TherapyId
            };
        }

        public OpdTherapyDueCollectionModel Create(OpdTherapyDueCollection obj)
        {
            return new OpdTherapyDueCollectionModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                //PatientId = obj.PatientId,
                VoucherNo = obj.VoucherNo,
                
                PreviousGivenAmount = obj.PreviousGivenAmount,
                TherapyId = obj.TherapyId,
            };
        }



        public OpdPatientDuebillCollectionModel Create(OpdPatientDuebillCollection obj)
        {
            return new OpdPatientDuebillCollectionModel
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                VoucherNo = obj.VoucherNo,
                //PatientId = obj.PatientId,
                PreviousGivenAmount = obj.PreviousGivenAmount,
                PurposeId = obj.PurposeId
            };
        }

        public OpdPatientDuebillCollection Create(OpdPatientDuebillCollectionModel obj)
        {
            return new OpdPatientDuebillCollection
            {
                Id = obj.Id,
                PatientCode = obj.PatientCode,
                CollectedDue = obj.CollectedDue,
                CollectionDate = obj.CollectionDate,
                DueAmount = obj.DueAmount,
                PreviousDue = obj.PreviousDue,
                //PatientId = obj.PatientId,
                VoucherNo = obj.VoucherNo,

                PreviousGivenAmount = obj.PreviousGivenAmount,
                PurposeId = obj.PurposeId,
            };
        }

        public DrugDepartmentWiseStockOut Create(DrugDepartmentWiseStockOutModel obj)
        {
            return new DrugDepartmentWiseStockOut
            {
                Id = obj.Id,
                DepartmentId = obj.DepartmentId,
                LotNo = obj.LotNo,
                MemoNo = obj.MemoNo,
                Date = obj.Date,
                TotalAmount = obj.TotalAmount,
                TotalQty = obj.TotalQty


            };
        }

        public DrugDepartmentWiseStockOutModel Create(DrugDepartmentWiseStockOut obj)
        {
            return new DrugDepartmentWiseStockOutModel
            {
                Id = obj.Id,
                DepartmentId = obj.DepartmentId,
                LotNo = obj.LotNo,
                MemoNo = obj.MemoNo,
                Date = obj.Date,
                TotalAmount = obj.TotalAmount,
                TotalQty = obj.TotalQty,
                DrugDepartmentWiseStockOutDetailsModel = obj.DrugDepartmentWiseStockOutDetails.Select(Create).ToList()


            };
        }



        public DrugDepartmentWiseStockOutDetails Create(DrugDepartmentWiseStockOutDetailsModel obj)
        {
            return new DrugDepartmentWiseStockOutDetails
            {
                Id = obj.Id,
                DRUGId = obj.DRUGId,

                DrugDepartmentWiseStockOutId = obj.DrugDepartmentWiseStockOutId,
                Quantity = obj.Quantity,
                SalePrice = obj.SalePrice,
                UnitPrice = obj.UnitPrice,
                SubTotalPrice = obj.SubTotalPrice


            };
        }

        public DrugDepartmentWiseStockOutDetailsModel Create(DrugDepartmentWiseStockOutDetails obj)
        {
            return new DrugDepartmentWiseStockOutDetailsModel
            {
                Id = obj.Id,
                DRUGId = obj.DRUGId,
                DrugName = obj.DRUG.D_TRADE_NAME + " " + obj.DRUG.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + (obj.DRUG.D_UNIT_STRENGTH),
                DrugDepartmentWiseStockOutId = obj.DrugDepartmentWiseStockOutId,
                Quantity = obj.Quantity,
                SalePrice = obj.SalePrice,
                UnitPrice = obj.UnitPrice,
                SubTotalPrice = obj.SubTotalPrice


            };
        }


        public InPatientDrugSaleReturn Create(InPatientDrugSaleReturnModel obj)
        {
            return new InPatientDrugSaleReturn
            {
                Id = obj.Id,

                ReturnPrice = obj.ReturnPrice,

                ReturnQty = obj.ReturnQty,
                LotNo = obj.LotNo,
                MemoNo = obj.MemoNo,
                PatientCode = obj.PatientCode,
                CreatedDate = obj.CreatedDate,
                ReturnDate = obj.ReturnDate,
                ReturnDiscount = obj.ReturnDiscount,
                ReturnSubTotal = obj.ReturnSubTotal,
                TxnNo = obj.TxnNo

            };
        }

        public InPatientDrugSaleReturnModel Create(InPatientDrugSaleReturn obj)
        {
            return new InPatientDrugSaleReturnModel
            {
                Id = obj.Id,

                ReturnPrice = obj.ReturnPrice,

                ReturnQty = obj.ReturnQty,
                LotNo = obj.LotNo,
                MemoNo = obj.MemoNo,
                PatientCode = obj.PatientCode,
                CreatedDate = obj.CreatedDate,
                ReturnDate = obj.ReturnDate,
                ReturnDiscount = obj.ReturnDiscount,
                ReturnSubTotal = obj.ReturnSubTotal,
                TxnNo = obj.TxnNo,
                InPatientDrugSaleReturnDetailsModels = obj.InPatientDrugSaleReturnDetails.Select(Create).ToList()
            };
        }





        public InPatientDrugSaleReturnDetails Create(InPatientDrugSaleReturnDetailsModel obj)
        {
            return new InPatientDrugSaleReturnDetails
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                ReturnPrice = obj.ReturnPrice,
                InPatientDrugSaleReturnId = obj.InPatientDrugSaleReturnId,
                ReturnQty = obj.ReturnQty,

            };
        }

        public InPatientDrugSaleReturnDetailsModel Create(InPatientDrugSaleReturnDetails obj)
        {
            return new InPatientDrugSaleReturnDetailsModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                ReturnPrice = obj.ReturnPrice,
                InPatientDrugSaleReturnId = obj.InPatientDrugSaleReturnId,
                ReturnQty = obj.ReturnQty,
                DrugName = obj.Drug.D_TRADE_NAME + " " + obj.Drug.D_UNIT_STRENGTH + " " + obj.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION
            };
        }

        public DataAccess.Entity.Vehicle Create(VehicleModel obj)
        {
            return new DataAccess.Entity.Vehicle
            {
                Id = obj.Id,
                VehicleId = obj.VehicleId,
                Title = obj.Title,
                Description = obj.Description,
                PurchaseDate = obj.PurchaseDate,

            };
        }

        public VehicleModel Create(DataAccess.Entity.Vehicle obj)
        {
            return new VehicleModel
            {
                Id = obj.Id,
                VehicleId = obj.VehicleId,
                Title = obj.Title,
                Description = obj.Description,
                PurchaseDate = obj.PurchaseDate
            };
        }

        public RentAmbulanceModel Create(RentAmbulance obj)
        {
            return new RentAmbulanceModel
            {
                Id = obj.Id,
                VehicleId = obj.VehicleId,
                VehicleName = obj.VehicleName,
                Mobile = obj.Mobile,
                Driver = obj.Driver,
                FromRoute = obj.FromRoute,
                ToRoute = obj.ToRoute,
                Kelometer = obj.Kelometer,
                Amount = obj.Amount,
                PartyContactName = obj.PartyContactName,
                PartyAddress = obj.PartyAddress,
                PartyMobileNumber = obj.PartyMobileNumber,
                VehicleFor = obj.VehicleFor,
                Date = obj.Date,
                Voucher = obj.Voucher,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                ModifiedDate = obj.ModifiedDate,
                ModifiedBy = obj.ModifiedBy
            };
        }

        public RentAmbulance Create(RentAmbulanceModel obj)
        {
            return new RentAmbulance
            {
                Id = obj.Id,
                VehicleId = obj.VehicleId,
                VehicleName = obj.VehicleName,
                Mobile = obj.Mobile,
                Driver = obj.Driver,
                FromRoute = obj.FromRoute,
                ToRoute = obj.ToRoute,
                Kelometer = obj.Kelometer,
                Amount = obj.Amount,
                PartyContactName = obj.PartyContactName,
                PartyAddress = obj.PartyAddress,
                PartyMobileNumber = obj.PartyMobileNumber,
                VehicleFor = obj.VehicleFor,
                Date = obj.Date,
                Voucher = obj.Voucher,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                ModifiedDate = obj.ModifiedDate,
                ModifiedBy = obj.ModifiedBy
            };
        }

        public Package Create(PackageModel obj)
        {
            return new Package
            {
                Id = obj.Id,
                Name = obj.Name,
                TotalPrice = obj.TotalPrice,
                Date = obj.Date,
                NoOfDays = obj.NoOfDays,
                CabinAmount = obj.CabinAmount,
                OTMedicineAmount = obj.OTMedicineAmount
            };
        }

        public PackageModel Create(Package obj)
        {
            return new PackageModel
            {
                Id = obj.Id,
                Name = obj.Name,
                TotalPrice = obj.TotalPrice,
                Date = obj.Date,
                NoOfDays = obj.NoOfDays,
                CabinAmount = obj.CabinAmount,
                OTMedicineAmount = obj.OTMedicineAmount,
                PackageDetailsModels = obj.PackageDetailses.Select(Create).ToList(),
                PackageExcludeModels = obj.PackageExcludes.Select(Create).ToList()
            };
        }

        public PackageDetails Create(PackageDetailsModel obj)
        {
            return new PackageDetails
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                PackageId = obj.PackageId
            };
        }

        public PackageDetailsModel Create(PackageDetails obj)
        {
            return new PackageDetailsModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
                PackageId = obj.PackageId

            };
        }
        public PackageExcludes Create(PackageExcludesModel obj)
        {
            return new PackageExcludes
            {
                Id = obj.Id,
                PackageId = obj.PackageId,
                Excludes = obj.Excludes
            };
        }

        public PackageExcludesModel Create(PackageExcludes obj)
        {
            return new PackageExcludesModel
            {
                Id = obj.Id,
                PackageId = obj.PackageId,
                Excludes = obj.Excludes

            };
        }
        public PatientEnrollDialysis Create(PatientEnrollDialysisModel obj)
        {
            return new PatientEnrollDialysis
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                SerialNo = obj.SerialNo,
                Date = obj.Date,
                Time = obj.Time,
                Type = obj.Type,
                Status = obj.Status,
            };
        }

        public PatientEnrollDialysisModel Create(PatientEnrollDialysis obj)
        {
            return new PatientEnrollDialysisModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientInformation.PatientCode,
                PatientName = obj.PatientInformation.Name,
                SerialNo = obj.SerialNo,
                Date = obj.Date,
                Time = obj.Time,
                Type = obj.Type,
                Status = obj.Status,
            };
        }

        public PatientDialysis Create(PatientDialysisModel obj)
        {
            return new PatientDialysis
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                MachinNumber = obj.MachinNumber,
                ConsultantName = obj.ConsultantName,
                ConsultantContactNumber = obj.ConsultantContactNumber,
                NoOfTakenDialysis = obj.NoOfTakenDialysis,
                LastDialysisTakenHospital = obj.LastDialysisTakenHospital,
                LastDialysisTakenDate = obj.LastDialysisTakenDate,
                Hemoglobin = obj.Hemoglobin,
                LastWeight = obj.LastWeight,
                PreDialysisBodyWeight = obj.PreDialysisBodyWeight,
                PreDialysisBodyBP = obj.PreDialysisBodyBP,
                PreDialysisBodyPulse = obj.PreDialysisBodyPulse,
                PreDialysisBodyResp = obj.PreDialysisBodyResp,
                PreDialysisBodyTemp = obj.PreDialysisBodyTemp,
                PostDialysisBodyWeight = obj.PostDialysisBodyWeight,
                PostDialysisBodyBP = obj.PostDialysisBodyBP,
                PostDialysisBodyPulse = obj.PostDialysisBodyPulse,
                PostDialysisBodyResp = obj.PostDialysisBodyResp,
                PostDialysisBodyTemp = obj.PostDialysisBodyTemp
            };
        }

        public PatientDialysisModel Create(PatientDialysis obj)
        {
            return new PatientDialysisModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientInformation.PatientCode,
                PatientName = obj.PatientInformation.Name,
                PatientAge = (DateTime.Now.Year - obj.PatientInformation.DateOfBirth.Year),
                BloodGroup = obj.PatientInformation.BloodGroup,
                Sex = obj.PatientInformation.Sex,
                MachinNumber = obj.MachinNumber,
                ConsultantName = obj.ConsultantName,
                ConsultantContactNumber = obj.ConsultantContactNumber,
                NoOfTakenDialysis = obj.NoOfTakenDialysis,
                LastDialysisTakenHospital = obj.LastDialysisTakenHospital,
                LastDialysisTakenDate = obj.LastDialysisTakenDate,
                Hemoglobin = obj.Hemoglobin,
                LastWeight = obj.LastWeight,
                PreDialysisBodyWeight = obj.PreDialysisBodyWeight,
                PreDialysisBodyBP = obj.PreDialysisBodyBP,
                PreDialysisBodyPulse = obj.PreDialysisBodyPulse,
                PreDialysisBodyResp = obj.PreDialysisBodyResp,
                PreDialysisBodyTemp = obj.PreDialysisBodyTemp,
                PostDialysisBodyWeight = obj.PostDialysisBodyWeight,
                PostDialysisBodyBP = obj.PostDialysisBodyBP,
                PostDialysisBodyPulse = obj.PostDialysisBodyPulse,
                PostDialysisBodyResp = obj.PostDialysisBodyResp,
                PostDialysisBodyTemp = obj.PostDialysisBodyTemp
            };
        }

        public DialysisPayment Create(DialysisPaymentModel obj)
        {
            return new DialysisPayment
            {
                Id = obj.Id,
                PatientDialysisEnrollId = obj.MsDialysisAmountPurposeId,
                MsDialysisAmountPurposeId = obj.MsDialysisAmountPurposeId,
                VisitNo = obj.VisitNo,
                GrossAmount = obj.GrossAmount,
                FinalAmount = obj.FinalAmount,
                Discount = obj.Discount,
                Reason = obj.Reason
            };
        }

        public DialysisPaymentModel Create(DialysisPayment obj)
        {
            return new DialysisPaymentModel
            {
                Id = obj.Id,
                PatientDialysisEnrollId = obj.MsDialysisAmountPurposeId,
                MsDialysisAmountPurposeId = obj.MsDialysisAmountPurposeId,
                MsDialysisAmountPurposeName = obj.MsDialysisAmountPurpose.Description,
                GrossAmount = obj.GrossAmount,
                FinalAmount = obj.FinalAmount,
                Voucher = obj.Voucher,
                Discount = obj.Discount,
                Reason = obj.Reason
            };
        }

        public MsDialysisAmountPurpose Create(MsDialysisAmountPurposeModel obj)
        {
            return new MsDialysisAmountPurpose
            {
                Id = obj.Id,
                Description = obj.Description,
                Amount = obj.Amount,
                Type = obj.Type,
            };
        }

        public MsDialysisAmountPurposeModel Create(MsDialysisAmountPurpose obj)
        {
            return new MsDialysisAmountPurposeModel
            {
                Id = obj.Id,
                Description = obj.Description,
                Amount = obj.Amount,
                Type = obj.Type,
            };
        }

        public Customer Create(CustomerModel obj)
        {
            return new Customer
            {
                Id = obj.Id,
                Name = obj.Name,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                CardId = obj.CardId,
                Email = obj.Email,
                Telephone = obj.Telephone,
                Mobile = obj.Mobile,
                AddressOne = obj.AddressOne,
                AddressTwo = obj.AddressTwo,
                CityName = obj.CityName,
                Country = obj.Country

            };
        }

        public CustomerModel Create(Customer obj)
        {
            return new CustomerModel
            {
                Id = obj.Id,
                Name = obj.Name,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                CardId = obj.CardId,
                Email = obj.Email,
                Telephone = obj.Telephone,
                Mobile = obj.Mobile,
                AddressOne = obj.AddressOne,
                AddressTwo = obj.AddressTwo,
                CityName = obj.CityName,
                Country = obj.Country

            };
        }

        public ProductModel Create(Product obj)
        {
            return new ProductModel
            {
                Id = obj.Id,
                CategoryId = obj.CategoryId,
                CategoryName = obj.Category.Name,
                Name = obj.Name,
                ShortDescription = obj.ShortDescription,
                FullDescription = obj.FullDescription,
                SupplierId = obj.SupplierId,
                StockQuantity = obj.StockQuantity,
                MinStockQuantity = obj.MinStockQuantity,
                Price = obj.Price,
                Vat = obj.Vat,
                ProductCost = obj.ProductCost,
                SpecialPrice = obj.SpecialPrice,
                SpecialPriceStartDateTimeUtc = obj.SpecialPriceStartDateTimeUtc,
                SpecialPriceEndDateTimeUtc = obj.SpecialPriceEndDateTimeUtc,
                PictureUrl = obj.PictureUrl,
                Weight = obj.Weight,
                Length = obj.Length,
                Height = obj.Height,
                Width = obj.Width,
                Published = obj.Published,
                Deleted = obj.Deleted,

            };
        }

        public Product Create(ProductModel obj)
        {
            return new Product
            {
                Id = obj.Id,
                CategoryId = obj.CategoryId,
                Name = obj.Name,
                ShortDescription = obj.ShortDescription,
                FullDescription = obj.FullDescription,
                SupplierId = obj.SupplierId,
                StockQuantity = obj.StockQuantity,
                MinStockQuantity = obj.MinStockQuantity,
                Price = obj.Price,
                Vat = obj.Vat,
                ProductCost = obj.ProductCost,
                SpecialPrice = obj.SpecialPrice,
                SpecialPriceStartDateTimeUtc = obj.SpecialPriceStartDateTimeUtc,
                SpecialPriceEndDateTimeUtc = obj.SpecialPriceEndDateTimeUtc,
                Weight = obj.Weight,
                Length = obj.Length,
                Height = obj.Height,
                Width = obj.Width,
                Published = obj.Published,
                Deleted = obj.Deleted

            };
        }

        public CategoryModel Create(Category obj)
        {
            return new CategoryModel
            {
                Id = obj.Id,
                Description = obj.Description,
                DisplayOrder = obj.DisplayOrder,
                IsFeaturedProduct = obj.IsFeaturedProduct,
                Name = obj.Name,
                PictureUrl = obj.PictureUrl,
                //ProductModels = obj.Products.Select(Create).ToList()
                //ProductId = obj.ProductId,
                //ProductName = obj.Product.Name
            };
        }

        public Category Create(CategoryModel obj)
        {
            return new Category
            {
                Id = obj.Id,
                Description = obj.Description,
                DisplayOrder = obj.DisplayOrder,
                IsFeaturedProduct = obj.IsFeaturedProduct,
                Name = obj.Name,
                PictureUrl = obj.PictureUrl,

                //ProductId = obj.ProductId,


            };
        }

        public SellsModel Create(Sells obj)
        {
            return new SellsModel
            {
                Id = obj.Id,
                CustomerId = obj.CustomerId,
                SellsNo = obj.SellsNo,
                SellsDate = obj.SellsDate,
                SubTotal = obj.SubTotal,
                GrandTotal = obj.GrandTotal,
                TransactionType = obj.TransactionType,
                TransactionNumber = obj.TransactionNumber,
                GivenAmount = obj.GivenAmount,
                ChangeAmount = obj.ChangeAmount,
                Status = obj.Status,
                Note = obj.Note,
                Discount = obj.Discount,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                ModifiedDate = obj.ModifiedDate,
                ModifiedBy = obj.ModifiedBy,
                SellsDetailsModels = obj.SellsDetails.Select(Create).ToList()

            };
        }

        public Sells Create(SellsModel obj)
        {
            return new Sells
            {
                Id = obj.Id,
                CustomerId = obj.CustomerId,
                SellsNo = obj.SellsNo,
                SellsDate = obj.SellsDate,
                SubTotal = obj.SubTotal,
                GrandTotal = obj.GrandTotal,
                TransactionType = obj.TransactionType,
                TransactionNumber = obj.TransactionNumber,
                GivenAmount = obj.GivenAmount,
                ChangeAmount = obj.ChangeAmount,
                Status = obj.Status,
                Note = obj.Note,
                Discount = obj.Discount,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                ModifiedDate = obj.ModifiedDate,
                ModifiedBy = obj.ModifiedBy,


            };
        }

        public SellsDetailsModel Create(SellsDetails obj)
        {
            return new SellsDetailsModel
            {
                Id = obj.Id,
                SellsId = obj.SellsId,
                ProductId = obj.ProductId,
                ProductName = obj.Product.Name,
                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotal = obj.SubTotal,
                Discount = obj.Discount,
                Total = obj.Total,
                CostPrice = obj.CostPrice,
                TotalCostPrice = obj.TotalCostPrice
            };
        }

        public SellsDetails Create(SellsDetailsModel obj)
        {
            return new SellsDetails
            {
                Id = obj.Id,
                SellsId = obj.SellsId,
                ProductId = obj.ProductId,

                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotal = obj.SubTotal,
                Discount = obj.Discount,
                Total = obj.Total,
                CostPrice = obj.CostPrice,
                TotalCostPrice = obj.TotalCostPrice
            };
        }

        public CanteenFoodInPatientModel Create(CanteenFoodInPatient obj)
        {
            return new CanteenFoodInPatientModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                SellsDate = obj.SellsDate,
                SellsNo = obj.SellsNo,
                GivenAmount = obj.GivenAmount,
                ChangeAmount = obj.ChangeAmount,
                VoucherNo = obj.VoucherNo,
                CanteenFoodInPatientDetailsModel = obj.CanteenFoodInPatientDetails.Select(Create).ToList()

            };
        }

        public CanteenFoodInPatient Create(CanteenFoodInPatientModel obj)
        {
            return new CanteenFoodInPatient
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                SellsDate = obj.SellsDate,
                SellsNo = obj.SellsNo,
                GivenAmount = obj.GivenAmount,
                ChangeAmount = obj.ChangeAmount,
                VoucherNo = obj.VoucherNo,


            };
        }

        public CanteenFoodInPatientDetailsModel Create(CanteenFoodInPatientDetails obj)
        {
            return new CanteenFoodInPatientDetailsModel
            {
                Id = obj.Id,
                CanteenFoodInPatientId = obj.CanteenFoodInPatientId,
                ProductId = obj.ProductId,
                ProductName = obj.Product.Name,
                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotal = obj.SubTotal,

                Total = obj.Total,
                CostPrice = obj.CostPrice,

            };
        }

        public CanteenFoodInPatientDetails Create(CanteenFoodInPatientDetailsModel obj)
        {
            return new CanteenFoodInPatientDetails
            {
                Id = obj.Id,
                CanteenFoodInPatientId = obj.CanteenFoodInPatientId,
                ProductId = obj.ProductId,

                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotal = obj.SubTotal,

                Total = obj.Total,
                CostPrice = obj.CostPrice,

            };
        }

        public OptPatientBill Create(OptPatientBillModel obj)
        {
            return new OptPatientBill
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                TotalAmount = obj.TotalAmount,
                GivenAmount = obj.GivenAmount,
                CreatedDate = obj.CreatedDate,
                MarketingBy = obj.MarketingBy,
                Remarks = obj.Remarks,
                Department = obj.Department,
                DueAmount = obj.DueAmount


            };
        }

        public OptPatientBillModel Create(OptPatientBill obj)
        {
            return new OptPatientBillModel
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                TotalAmount = obj.TotalAmount,
                GivenAmount = obj.GivenAmount,
                CreatedDate = obj.CreatedDate,
                MarketingBy = obj.MarketingBy,
                Remarks = obj.Remarks,
                Department = obj.Department,
                DueAmount = obj.DueAmount,
                OptPatientBillDetailsModels = obj.OptPatientBillDetails.Select(Create).ToList()





            };
        }

        public OptPatientBillDetails Create(OptPatientBillDetailsModel obj)
        {
            return new OptPatientBillDetails
            {
                Id = obj.Id,
                OptPatientBillId = obj.OptPatientBillId,
                PurposeId = obj.PurposeId,
                Quantity = obj.Quantity,
                Amount = obj.Amount,
                SubTotal = obj.SubTotal

            };
        }

        public OptPatientBillDetailsModel Create(OptPatientBillDetails obj)
        {
            return new OptPatientBillDetailsModel
            {
                Id = obj.Id,
                OptPatientBillId = obj.OptPatientBillId,

                PurposeId = obj.PurposeId,
                PurposeName = obj.Purpose.PurposeDescription,
                Quantity = obj.Quantity,
                Amount = obj.Amount,
                SubTotal = obj.SubTotal





            };
        }



        public PatientCard Create(PatientCardModel obj)
        {
            return new PatientCard
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                RegistrationFee = obj.RegistrationFee,
                CreatedDate = obj.CreatedDate,


            };
        }

        public PatientCardModel Create(PatientCard obj)
        {
            return new PatientCardModel
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                RegistrationFee = obj.RegistrationFee,
                CreatedDate = obj.CreatedDate,





            };
        }

        public BillingForCheckupPackage Create(BillingForCheckupPackageModel obj)
        {
            return new BillingForCheckupPackage
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,

                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                TotalAmount = obj.TotalAmount,
                GivenAmount = obj.GivenAmount,
                CreatedDate = obj.CreatedDate,
                Remarks = obj.Remarks


            };
        }

        public BillingForCheckupPackageModel Create(BillingForCheckupPackage obj)
        {
            return new BillingForCheckupPackageModel
            {
                Id = obj.Id,

                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                EducationId = obj.EducationId,
                OccupationId = obj.OccupationId,
                Age = obj.Age,
                Address = obj.Address,
                BloodGroup = obj.BloodGroup,
                PatientName = obj.PatientName,
                Sex = obj.Sex,

                MobileNumber = obj.MobileNumber,
                ReferanceName = obj.ReferanceName,
                TotalAmount = obj.TotalAmount,
                GivenAmount = obj.GivenAmount,
                CreatedDate = obj.CreatedDate,
                Remarks = obj.Remarks,
                BillingForCheckupPackageDetailsModel = obj.BillingForCheckupPackageDetails.Select(Create).ToList(),






            };
        }


        public BillingForCheckupPackageDetails Create(BillingForCheckupPackageDetailsModel obj)
        {
            return new BillingForCheckupPackageDetails
            {
                Id = obj.Id,
                BillingForCheckupPackageId = obj.BillingForCheckupPackageId,
                PackageForCheckUpId = obj.PackageForCheckUpId,
                Quantity = obj.Quantity,
                Amount = obj.Amount,
                SubTotal = obj.SubTotal

            };
        }

        public BillingForCheckupPackageDetailsModel Create(BillingForCheckupPackageDetails obj)
        {
            return new BillingForCheckupPackageDetailsModel
            {
                Id = obj.Id,
                BillingForCheckupPackageId = obj.BillingForCheckupPackageId,
                PackageForCheckUpId = obj.PackageForCheckUpId,
                PackageForCheckUpName = obj.PackageForCheckUp.Name,
                Quantity = obj.Quantity,
                Amount = obj.Amount,
                SubTotal = obj.SubTotal

            };
        }


        public InPatientTest Create(InPatientTestModel obj)
        {
            return new InPatientTest
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                ItemQuantity = obj.ItemQuantity,
                DeuAmount = obj.DeuAmount,
                TestDate = obj.TestDate,
                AdmissionNo = obj.AdmissionNo,
                CreatedDate = obj.CreatedDate,
                Remark = obj.Remark

            };
        }

        public InPatientTestModel Create(InPatientTest obj)
        {
            return new InPatientTestModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                VoucherNo = obj.VoucherNo,
                ItemQuantity = obj.ItemQuantity,
                DeuAmount = obj.DeuAmount,
                TestDate = obj.TestDate,
                AdmissionNo = obj.AdmissionNo,
                CreatedDate = obj.CreatedDate,
                Remark = obj.Remark,
                InPatientTestdetailsModels = obj.InPatientTestDetails.Select(Create).ToList()





            };
        }

        public InPatientTestdetails Create(InPatientTestdetailsModel obj)
        {
            return new InPatientTestdetails
            {
                Id = obj.Id,
                TestNameId = obj.TestNameId,
                InPatientTestId = obj.InPatientTestId,
                Price = obj.Price,
                Discount = obj.Discount,
                Total = obj.Total,
                Quantity = obj.Quantity
            };
        }

        public InPatientTestdetailsModel Create(InPatientTestdetails obj)
        {
            return new InPatientTestdetailsModel
            {
                Id = obj.Id,

                TestNameId = obj.TestNameId,
                TestName = obj.TestName.T_NAME,
                InPatientTestId = obj.InPatientTestId,
                Price = obj.Price,
                Discount = obj.Discount,
                Total = obj.Total,
                Quantity = obj.Quantity



            };
        }




        public InPatientDoctorInvoice Create(InPatientDoctorInvoiceModel obj)
        {
            return new InPatientDoctorInvoice
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                DoctorId = obj.DoctorId,
                Date = obj.Date,
                AdmissionNo = obj.AdmissionNo,
                CreatedDate = obj.CreatedDate,
                Amount = obj.Amount
            };
        }

        public InPatientDoctorInvoiceModel Create(InPatientDoctorInvoice obj)
        {
            return new InPatientDoctorInvoiceModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.Doctor.Name,
                AdmissionNo = obj.AdmissionNo,
                Date = obj.Date,
                CreatedDate = obj.CreatedDate,
                Amount = obj.Amount





            };
        }


        public InPatientDischarge Create(InPatientDischargeModel obj)
        {
            return new InPatientDischarge
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                CabinId = obj.CabinId,
                BedId = obj.BedId,
                WardId = obj.WardId,
                CabinAmount = obj.CabinAmount,
                DischargeDate = obj.DischargeDate,
                InPatientDailyBill = obj.InPatientDailyBill,
                InPatientDrugBill = obj.InPatientDrugBill,
                InPatientDoctorBills = obj.InPatientDoctorBills,
                InPatientTotalTestBills = obj.InPatientTotalTestBills,
                TotalBill = obj.TotalBill,
                Status = obj.Status,

                ServiceCharge = obj.ServiceCharge,
                PackageId = obj.PackageId,
                PackageAmount = obj.PackageAmount,
                Discount = obj.Discount,
                DiscountReason = obj.DiscountReason,
                AdmissionFee = obj.AdmissionFee,
                DoctorDiscount = obj.DoctorDiscount,
                NameOfDoctorOnDiscount = obj.NameOfDoctorOnDiscount,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                ICUBill = obj.ICUBill,
                OTBill = obj.OTBill,
                DueAmount = obj.DueAmount,
                PaymentAmount = obj.PaymentAmount


            };
        }

        public InPatientDischargeModel Create(InPatientDischarge obj)
        {
            return new InPatientDischargeModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                CabinId = obj.CabinId,
                BedId = obj.BedId,
                WardId = obj.WardId,
                CabinAmount = obj.CabinAmount,
                DischargeDate = obj.DischargeDate,
                InPatientDailyBill = obj.InPatientDailyBill,
                InPatientDrugBill = obj.InPatientDrugBill,
                InPatientDoctorBills = obj.InPatientDoctorBills,
                InPatientTotalTestBills = obj.InPatientTotalTestBills,
                TotalBill = obj.TotalBill,
                Status = obj.Status,

                ServiceCharge = obj.ServiceCharge,
                PackageId = obj.PackageId,
                PackageAmount = obj.PackageAmount,
                Discount = obj.Discount,
                DiscountReason = obj.DiscountReason,
                AdmissionFee = obj.AdmissionFee,
                DoctorDiscount = obj.DoctorDiscount,
                NameOfDoctorOnDiscount = obj.NameOfDoctorOnDiscount,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                ICUBill = obj.ICUBill,
                OTBill = obj.OTBill,
                DueAmount = obj.DueAmount,
                PaymentAmount = obj.PaymentAmount
            };
        }



        public IpdDraft Create(InPatientDischargeDraftModel obj)
        {
            return new IpdDraft
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                CabinId = obj.CabinId,
                BedId = obj.BedId,
                WardId = obj.WardId,
                CabinAmount = obj.CabinAmount,
                DischargeDate = obj.DischargeDate,
                InPatientDailyBill = obj.InPatientDailyBill,
                InPatientDrugBill = obj.InPatientDrugBill,
                InPatientDoctorBills = obj.InPatientDoctorBills,
                InPatientTotalTestBills = obj.InPatientTotalTestBills,
                TotalBill = obj.TotalBill,
                Status = obj.Status,

                ServiceCharge = obj.ServiceCharge,
                PackageId = obj.PackageId,
                PackageAmount = obj.PackageAmount,
                Discount = obj.Discount,
                DiscountReason = obj.DiscountReason,
                AdmissionFee = obj.AdmissionFee,
                DoctorDiscount = obj.DoctorDiscount,
                NameOfDoctorOnDiscount = obj.NameOfDoctorOnDiscount,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                TransferredCabinBill = obj.TransferredCabinBill,
                TransferredCabinName = obj.TransferredCabinName

            };
        }

        public InPatientDischargeDraftModel Create(IpdDraft obj)
        {
            return new InPatientDischargeDraftModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                CabinId = obj.CabinId,
                BedId = obj.BedId,
                WardId = obj.WardId,
                CabinAmount = obj.CabinAmount,
                DischargeDate = obj.DischargeDate,
                InPatientDailyBill = obj.InPatientDailyBill,
                InPatientDrugBill = obj.InPatientDrugBill,
                InPatientDoctorBills = obj.InPatientDoctorBills,
                InPatientTotalTestBills = obj.InPatientTotalTestBills,
                TotalBill = obj.TotalBill,
                Status = obj.Status,

                ServiceCharge = obj.ServiceCharge,
                PackageId = obj.PackageId,
                PackageAmount = obj.PackageAmount,
                Discount = obj.Discount,
                DiscountReason = obj.DiscountReason,
                AdmissionFee = obj.AdmissionFee,
                DoctorDiscount = obj.DoctorDiscount,
                NameOfDoctorOnDiscount = obj.NameOfDoctorOnDiscount,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }





        public InPatientDrug Create(InPatientDrugModel obj)
        {
            return new InPatientDrug
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                Quantity = obj.Quantity,
                SaleDateTime = obj.SaleDateTime,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TotalPrice = obj.TotalPrice,
                Vat = obj.Vat,
                VoucherNo = obj.VoucherNo,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Remarks = obj.Remarks

            };
        }

        public InPatientDrugModel Create(InPatientDrug obj)
        {
            return new InPatientDrugModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                Quantity = obj.Quantity,
                SaleDateTime = obj.SaleDateTime,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TotalPrice = obj.TotalPrice,
                Vat = obj.Vat,
                VoucherNo = obj.VoucherNo,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Remarks = obj.Remarks,
                InPatientDrugDetailsModel = obj.InPatientDrugDetails.Select(Create).ToList()





            };
        }

        public InPatientDrugDetails Create(InPatientDrugDetailsModel obj)
        {
            return new InPatientDrugDetails
            {
                Id = obj.Id,

                Quantity = obj.Quantity,

                SaleDiscount = obj.SaleDiscount,
                DrugId = obj.DrugId,
                InPatientDrugId = obj.InPatientDrugId,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total


            };
        }

        public InPatientDrugDetailsModel Create(InPatientDrugDetails obj)
        {
            return new InPatientDrugDetailsModel
            {
                Id = obj.Id,

                Quantity = obj.Quantity,

                SaleDiscount = obj.SaleDiscount,

                DrugId = obj.DrugId,
                DrugName = obj.Drug.D_TRADE_NAME,
                UnitStrength = obj.Drug.D_UNIT_STRENGTH,
                InPatientDrugId = obj.InPatientDrugId,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total



            };
        }
        public InPatientDailyBill Create(InPatientDailyBillModel obj)
        {
            return new InPatientDailyBill
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                CabinId = obj.CabinId,
                WardId = obj.WardId,
                BedId = obj.BedId,
                VoucherNo = obj.VoucherNo,
                NoOfDays = obj.NoOfDays,
                DateOfAdmission = obj.DateOfAdmission,
                TransactionNumber = obj.TransactionNumber,
                TransactionType = obj.TransactionType,
                SubTotal = obj.SubTotal,
                Total = obj.Total,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Remarks = obj.Remarks,


            };
        }

        public InPatientDailyBillModel Create(InPatientDailyBill obj)
        {
            return new InPatientDailyBillModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                CabinId = obj.CabinId,
                WardId = obj.WardId,
                BedId = obj.BedId,
                VoucherNo = obj.VoucherNo,
                NoOfDays = obj.NoOfDays,
                DateOfAdmission = obj.DateOfAdmission,
                TransactionNumber = obj.TransactionNumber,
                TransactionType = obj.TransactionType,
                SubTotal = obj.SubTotal,
                Total = obj.Total,

                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Remarks = obj.Remarks,
                InPatientDailyBillDetailsModels = obj.InPatientDailyBillDetails.Select(Create).ToList()





            };
        }

        public InPatientDailyBillDetails Create(InPatientDailyBillDetailsModel obj)
        {
            return new InPatientDailyBillDetails
            {
                Id = obj.Id,
                InPatientDailyBillId = obj.InPatientDailyBillId,
                PurposeId = obj.PurposeId,
                Rate = obj.Rate,
                Quantity = obj.Quantity,
                SubTotal = obj.SubTotal,
                Total = obj.Total



            };
        }

        public InPatientDailyBillDetailsModel Create(InPatientDailyBillDetails obj)
        {
            return new InPatientDailyBillDetailsModel
            {
                Id = obj.Id,
                InPatientDailyBillId = obj.InPatientDailyBillId,
                PurposeId = obj.PurposeId,
                PurposeName = obj.Purpose.PurposeDescription,
                Rate = obj.Rate,
                Quantity = obj.Quantity,
                SubTotal = obj.SubTotal,
                Total = obj.Total





            };
        }

        public PatientLaser Create(PatientLaserModel obj)
        {
            return new PatientLaser
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                CabinId = obj.CabinId,
                WardId = obj.WardId,
                BedId = obj.BedId,
                AdvanceAmount = obj.AdvanceAmount,
                AdvanceType = obj.AdvanceType,
                ChequeNumber = obj.ChequeNumber,
                BankName = obj.BankName,
                ReceivedDate = obj.ReceivedDate,

                Remarks = obj.Remarks,
                VoucherNo = obj.VoucherNo,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate



            };
        }

        public PatientLaserModel Create(PatientLaser obj)
        {
            return new PatientLaserModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                CabinId = obj.CabinId,
                WardId = obj.WardId,
                BedId = obj.BedId,
                AdvanceAmount = obj.AdvanceAmount,
                AdvanceType = obj.AdvanceType,
                ChequeNumber = obj.ChequeNumber,
                BankName = obj.BankName,
                ReceivedDate = obj.ReceivedDate,

                Remarks = obj.Remarks,
                VoucherNo = obj.VoucherNo,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate



            };
        }




        public Purpose Create(PurposeModel obj)
        {
            return new Purpose
            {
                Id = obj.Id,
                PurposeDescription = obj.PurposeDescription,
                Amount = obj.Amount



            };
        }

        public PurposeModel Create(Purpose obj)
        {
            return new PurposeModel
            {
                Id = obj.Id,

                PurposeDescription = obj.PurposeDescription,
                Amount = obj.Amount
                //PurchaseOrderDetailsModels = obj.PurchaseOrderDetails.Select(Create).ToList()



            };
        }


        public PatientAdmission Create(PatientAdmissionModel obj)
        {
            return new PatientAdmission
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                //PatientInformationId = obj.PatientId,
                PatientCode = obj.PatientCode,
                DeuAmount = obj.DeuAmount,
                GivenAmount = obj.GivenAmount,

                CabinAmount = obj.CabinAmount,
                TotalAmount = obj.TotalAmount,
                VoucherNo = obj.VoucherNo,
                CabinRentDate = obj.CabinRentDate,
                NoOfDays = obj.NoOfDays,
                EmergencyContactMobile = obj.EmergencyContactMobile,
                EmergencyContactName = obj.EmergencyContactName,
                EmergencyContactPersonAddress = obj.EmergencyContactPersonAddress,
                EmergencyContactPersonRelation = obj.EmergencyContactPersonRelation,
                RrreferenceDoctor = obj.RrreferenceDoctor,
                Telephone = obj.Telephone,
                HomePhone = obj.HomePhone,
                AdmissionFee = obj.AdmissionFee,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate


            };
        }

        public PatientAdmissionModel Create(PatientAdmission obj)
        {
            return new PatientAdmissionModel
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                CabinName = obj.Cabin.Name,
                //PatientId = obj.PatientInformationId,
                //PatientName = obj.PatientInformation.Name,
                PatientCode = obj.PatientCode,
                DeuAmount = obj.DeuAmount,
                GivenAmount = obj.GivenAmount,
                CabinAmount = obj.CabinAmount,
                TotalAmount = obj.TotalAmount,
                VoucherNo = obj.VoucherNo,
                CabinRentDate = obj.CabinRentDate,
                NoOfDays = obj.NoOfDays,
                //PatientAdmissionDetailsModels = obj.PatientAdmissionDetails.Select(Create).ToList()
                EmergencyContactMobile = obj.EmergencyContactMobile,
                EmergencyContactName = obj.EmergencyContactName,
                EmergencyContactPersonAddress = obj.EmergencyContactPersonAddress,
                EmergencyContactPersonRelation = obj.EmergencyContactPersonRelation,
                RrreferenceDoctor = obj.RrreferenceDoctor,
                Telephone = obj.Telephone,
                HomePhone = obj.HomePhone,
                AdmissionFee = obj.AdmissionFee,
                AdmissionNo = obj.AdmissionNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }
        public PatientAdmissionDetails Create(PatientAdmissionDetailsModel obj)
        {
            return new PatientAdmissionDetails
            {
                Id = obj.Id,
                PurposeId = obj.PurposeId,
                PatientAdmissionId = obj.PatientAdmissionId,
                CreatedDate = obj.CreatedDate,
                Amount = obj.Amount,




            };
        }

        public PatientAdmissionDetailsModel Create(PatientAdmissionDetails obj)
        {
            return new PatientAdmissionDetailsModel
            {
                Id = obj.Id,
                PurposeId = obj.PurposeId,
                PatientAdmissionId = obj.PatientAdmissionId,
                CreatedDate = obj.CreatedDate,
                Amount = obj.Amount,
                PurposeName = obj.Purpose.PurposeDescription


            };
        }
        public PurchaseOrder Create(PurchaseOrderModel obj)
        {
            return new PurchaseOrder
            {
                Id = obj.Id,
                LotId = obj.LotId,
                MemoNo = obj.MemoNo,
                TxnNo = obj.TxnNo,
                DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,
                TotalPrice = obj.TotalPrice,
                TotalQty = obj.TotalQty,
                RecordDate = obj.RecordDate



            };
        }

        public PurchaseOrderModel Create(PurchaseOrder obj)
        {
            return new PurchaseOrderModel
            {
                Id = obj.Id,
                LotId = obj.LotId,
                MemoNo = obj.MemoNo,
                TxnNo = obj.TxnNo,
                DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,
                TotalPrice = obj.TotalPrice,
                TotalQty = obj.TotalQty,
                DRUG_MANUFACTURERName = obj.DRUG_MANUFACTURER.DM_NAME,
                RecordDate = obj.RecordDate,
                PurchaseOrderDetailsModels = obj.PurchaseOrderDetails.Select(Create).ToList()



            };
        }


        public PurchaseOrderDetails Create(PurchaseOrderDetailsModel obj)
        {
            return new PurchaseOrderDetails
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugPresentationType = obj.DrugPresentationType,
                DrugUnitStrength = obj.DrugUnitStrength,
                PurchaseOrderId = obj.PurchaseOrderId,
                Discount = obj.Discount,
                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotalPrice = obj.SubTotalPrice,



            };
        }

        public PurchaseOrderDetailsModel Create(PurchaseOrderDetails obj)
        {
            return new PurchaseOrderDetailsModel
            {
                Id = obj.Id,

                DrugId = obj.DrugId,
                DrugPresentationType = obj.DrugPresentationType,
                DrugUnitStrength = obj.DrugUnitStrength,
                PurchaseOrderId = obj.PurchaseOrderId,
                Discount = obj.Discount,
                Quantity = obj.Quantity,
                UnitPrice = obj.UnitPrice,
                SubTotalPrice = obj.SubTotalPrice,
                DrugName = obj.DRUG.D_TRADE_NAME


            };
        }

        public MicrobiologyTest Create(MicrobiologyTestModel obj)
        {
            return new MicrobiologyTest
            {
                Id = obj.Id,
                SpecimenName = obj.SpecimenName,
                Amikacin = obj.Amikacin,
                Amoxycillin = obj.Amoxycillin,
                Amoxyclav = obj.Amoxyclav,
                Ampicillin = obj.Ampicillin,
                Azithromycin = obj.Azithromycin,
                Carbinicillin = obj.Carbinicillin,
                Cefepime = obj.Cefepime,
                Cefixime = obj.Cefixime,
                Cefotaxime = obj.Cefotaxime,
                Ceftazidime = obj.Ceftazidime,
                Ceftiaxone = obj.Ceftiaxone,
                Cefuroxime = obj.Cefuroxime,
                Cepepime = obj.Cepepime,
                Cephalexine = obj.Cephalexine,
                Cephradine = obj.Cephradine,
                Chloramphenicol = obj.Chloramphenicol,
                Ciprofloxacin = obj.Ciprofloxacin,
                Clindamycin = obj.Clindamycin,
                Cloxacillin = obj.Cloxacillin,
                Colistin = obj.Colistin,
                Cotrimoxazole = obj.Cotrimoxazole,
                Doripenum = obj.Doripenum,
                Doxycycline = obj.Doxycycline,
                Erythromycin = obj.Erythromycin,
                FusidicAcid = obj.FusidicAcid,
                Gentamycin = obj.Gentamycin,
                Imipenem = obj.Imipenem,
                Levofloxacin = obj.Levofloxacin,
                Linezolid = obj.Linezolid,
                Mecillinam = obj.Mecillinam,
                Meropenem = obj.Meropenem,
                NalidexicAcid = obj.NalidexicAcid,
                Netilmycin = obj.Netilmycin,
                Nitrofurantion = obj.Nitrofurantion,
                Oxacillin = obj.Oxacillin,
                Penicillin = obj.Penicillin,
                PiperacillinOrTazobactam = obj.PiperacillinOrTazobactam,
                Rifampicin = obj.Rifampicin,
                Tetracycline = obj.Tetracycline,
                Ticarcillin = obj.Ticarcillin,
                Tigecycline = obj.Tigecycline,
                Tobramycin = obj.Tobramycin,
                Vancomycin = obj.Vancomycin,
                PatientId = obj.PatientId,
                PatientAge = obj.PatientAge,
                OrganismIsolated = obj.OrganismIsolated,
                Culture = obj.Culture,
                ReferredBy = obj.ReferredBy,




            };
        }

        public MicrobiologyTestModel Create(MicrobiologyTest obj)
        {
            return new MicrobiologyTestModel
            {
                Id = obj.Id,
                //SpecimenName = obj.SpecimenName,
                Amikacin = obj.Amikacin,
                Amoxycillin = obj.Amoxycillin,
                Amoxyclav = obj.Amoxyclav,
                Ampicillin = obj.Ampicillin,
                Azithromycin = obj.Azithromycin,
                Carbinicillin = obj.Carbinicillin,
                Cefepime = obj.Cefepime,
                Cefixime = obj.Cefixime,
                Cefotaxime = obj.Cefotaxime,
                Ceftazidime = obj.Ceftazidime,
                Ceftiaxone = obj.Ceftiaxone,
                Cefuroxime = obj.Cefuroxime,
                Cepepime = obj.Cepepime,
                Cephalexine = obj.Cephalexine,
                Cephradine = obj.Cephradine,
                Chloramphenicol = obj.Chloramphenicol,
                Ciprofloxacin = obj.Ciprofloxacin,
                Clindamycin = obj.Clindamycin,
                Cloxacillin = obj.Cloxacillin,
                Colistin = obj.Colistin,
                Cotrimoxazole = obj.Cotrimoxazole,
                Doripenum = obj.Doripenum,
                Doxycycline = obj.Doxycycline,
                Erythromycin = obj.Erythromycin,
                FusidicAcid = obj.FusidicAcid,
                Gentamycin = obj.Gentamycin,
                Imipenem = obj.Imipenem,
                Levofloxacin = obj.Levofloxacin,
                Linezolid = obj.Linezolid,
                Mecillinam = obj.Mecillinam,
                Meropenem = obj.Meropenem,
                NalidexicAcid = obj.NalidexicAcid,
                Netilmycin = obj.Netilmycin,
                Nitrofurantion = obj.Nitrofurantion,
                Oxacillin = obj.Oxacillin,
                Penicillin = obj.Penicillin,
                PiperacillinOrTazobactam = obj.PiperacillinOrTazobactam,
                Rifampicin = obj.Rifampicin,
                Tetracycline = obj.Tetracycline,
                Ticarcillin = obj.Ticarcillin,
                Tigecycline = obj.Tigecycline,
                Tobramycin = obj.Tobramycin,
                Vancomycin = obj.Vancomycin,

                PatientId = obj.PatientId,
                PatientAge = obj.PatientAge,
                OrganismIsolated = obj.OrganismIsolated,
                Culture = obj.Culture,
                ReferredBy = obj.ReferredBy,
                SpecimenName = obj.SpecimenName,
                PatientName = obj.Patient.Name
            };
        }

        public SRETest Create(SRETestModel obj)
        {
            return new SRETest
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                Consistency = obj.Consistency,
                Colour = obj.Colour,
                Mucus = obj.Mucus,
                Blood = obj.Blood,
                Reaction = obj.Reaction,
                Protozoa = obj.Protozoa,
                PusCells = obj.PusCells,
                Ova = obj.Ova,
                MuscleFibres = obj.MuscleFibres,
                FatGlobules = obj.FatGlobules,
                RedBloodCells = obj.RedBloodCells,
                OccultBloodTest = obj.OccultBloodTest,
                Cysts = obj.Cysts,
                VegetableCells = obj.VegetableCells,
                Macrophage = obj.Macrophage,
                ReducingSubstance = obj.ReducingSubstance,
                StarchGranules = obj.StarchGranules,
                Others = obj.Others,

                ConsistencyUnit = obj.ConsistencyUnit,
                ColourUnit = obj.ColourUnit,
                MucusUnit = obj.MucusUnit,
                BloodUnit = obj.BloodUnit,
                ReactionUnit = obj.ReactionUnit,
                ProtozoaUnit = obj.ProtozoaUnit,
                PusCellsUnit = obj.PusCellsUnit,
                OvaUnit = obj.OvaUnit,
                MuscleFibresUnit = obj.MuscleFibresUnit,
                FatGlobulesUnit = obj.FatGlobulesUnit,
                RedBloodCellsUnit = obj.RedBloodCellsUnit,
                OccultBloodTestUnit = obj.OccultBloodTestUnit,
                CystsUnit = obj.CystsUnit,
                VegetableCellsUnit = obj.VegetableCellsUnit,
                MacrophageUnit = obj.MacrophageUnit,
                ReducingSubstanceUnit = obj.ReducingSubstanceUnit,
                StarchGranulesUnit = obj.StarchGranulesUnit,
                OthersUnit = obj.OthersUnit,

                ConsistencyRefer = obj.ConsistencyRefer,
                ColourRefer = obj.ColourRefer,
                MucusRefer = obj.MucusRefer,
                BloodRefer = obj.BloodRefer,
                ReactionRefer = obj.ReactionRefer,
                ProtozoaRefer = obj.ProtozoaRefer,
                PusCellsRefer = obj.PusCellsRefer,
                OvaRefer = obj.OvaRefer,
                MuscleFibresRefer = obj.MuscleFibres,
                FatGlobulesRefer = obj.FatGlobulesRefer,
                RedBloodCellsRefer = obj.RedBloodCellsRefer,
                OccultBloodTestRefer = obj.OccultBloodTestRefer,
                CystsRefer = obj.CystsRefer,
                VegetableCellsRefer = obj.VegetableCellsRefer,
                MacrophageRefer = obj.MacrophageRefer,
                ReducingSubstanceRefer = obj.ReducingSubstanceRefer,
                StarchGranulesRefer = obj.StarchGranulesRefer,
                OthersRefer = obj.OthersRefer,
                Department = obj.Department,
                Date = obj.Date,




            };
        }

        public SRETestModel Create(SRETest obj)
        {
            return new SRETestModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                SpecimenName = obj.SpecimenName,
                ReferanceName = obj.ReferanceName,
                Consistency = obj.Consistency,
                Colour = obj.Colour,
                Mucus = obj.Mucus,
                Blood = obj.Blood,
                Reaction = obj.Reaction,
                Protozoa = obj.Protozoa,
                PusCells = obj.PusCells,
                Ova = obj.Ova,
                MuscleFibres = obj.MuscleFibres,
                FatGlobules = obj.FatGlobules,
                RedBloodCells = obj.RedBloodCells,
                OccultBloodTest = obj.OccultBloodTest,
                Cysts = obj.Cysts,
                VegetableCells = obj.VegetableCells,
                Macrophage = obj.Macrophage,
                ReducingSubstance = obj.ReducingSubstance,
                StarchGranules = obj.StarchGranules,
                Others = obj.Others,

                ConsistencyUnit = obj.ConsistencyUnit,
                ColourUnit = obj.ColourUnit,
                MucusUnit = obj.MucusUnit,
                BloodUnit = obj.BloodUnit,
                ReactionUnit = obj.ReactionUnit,
                ProtozoaUnit = obj.ProtozoaUnit,
                PusCellsUnit = obj.PusCellsUnit,
                OvaUnit = obj.OvaUnit,
                MuscleFibresUnit = obj.MuscleFibresUnit,
                FatGlobulesUnit = obj.FatGlobulesUnit,
                RedBloodCellsUnit = obj.RedBloodCellsUnit,
                OccultBloodTestUnit = obj.OccultBloodTestUnit,
                CystsUnit = obj.CystsUnit,
                VegetableCellsUnit = obj.VegetableCellsUnit,
                MacrophageUnit = obj.MacrophageUnit,
                ReducingSubstanceUnit = obj.ReducingSubstanceUnit,
                StarchGranulesUnit = obj.StarchGranulesUnit,
                OthersUnit = obj.OthersUnit,

                ConsistencyRefer = obj.ConsistencyRefer,
                ColourRefer = obj.ColourRefer,
                MucusRefer = obj.MucusRefer,
                BloodRefer = obj.BloodRefer,
                ReactionRefer = obj.ReactionRefer,
                ProtozoaRefer = obj.ProtozoaRefer,
                PusCellsRefer = obj.PusCellsRefer,
                OvaRefer = obj.OvaRefer,
                MuscleFibresRefer = obj.MuscleFibres,
                FatGlobulesRefer = obj.FatGlobulesRefer,
                RedBloodCellsRefer = obj.RedBloodCellsRefer,
                OccultBloodTestRefer = obj.OccultBloodTestRefer,
                CystsRefer = obj.CystsRefer,
                VegetableCellsRefer = obj.VegetableCellsRefer,
                MacrophageRefer = obj.MacrophageRefer,
                ReducingSubstanceRefer = obj.ReducingSubstanceRefer,
                StarchGranulesRefer = obj.StarchGranulesRefer,
                OthersRefer = obj.OthersRefer,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date,




            };
        }

        public RETest Create(RETestModel obj)
        {
            return new RETest
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                Blood = obj.Blood,
                SpecimenName = obj.SpecimenName,
                ReferanceName = obj.ReferanceName,
                Clarity = obj.Clarity,
                Others = obj.Others,
                Crystals = obj.Crystals,
                Colour = obj.Colour,
                Turbidity = obj.Turbidity,
                Sediment = obj.Sediment,
                Specificgravity = obj.Specificgravity,
                PH = obj.PH,
                Protein = obj.Protein,
                Glucose = obj.Glucose,
                Puscells = obj.Puscells,
                Ketones = obj.Ketones,
                Urobilinogen = obj.Urobilinogen,
                RbcCast = obj.RbcCast,
                Nitrite = obj.Nitrite,
                RedBloodCell = obj.RedBloodCell,
                CalciumOxalate = obj.CalciumOxalate,
                HyalineCast = obj.HyalineCast,
                GranularCast = obj.GranularCast,
                EpithelialCells = obj.EpithelialCells,
                Spermatozoa = obj.Spermatozoa,
                Bilirubin = obj.Bilirubin,
                Amorphosphate = obj.Amorphosphate,
                TrichomonasVaginalis = obj.TrichomonasVaginalis,
                TriplePhosphate = obj.TriplePhosphate,
                UricAcid = obj.UricAcid,
                YeastCandida = obj.YeastCandida,
                WbcCast = obj.WbcCast,
                Albumin = obj.Albumin,
                BloodUnit = obj.BloodUnit,

                ClarityUnit = obj.ClarityUnit,
                OthersUnit = obj.OthersUnit,
                CrystalsUnit = obj.CrystalsUnit,
                ColourUnit = obj.ColourUnit,
                TurbidityUnit = obj.TurbidityUnit,
                SedimentUnit = obj.SedimentUnit,
                SpecificgravityUnit = obj.SpecificgravityUnit,
                PHUnit = obj.PHUnit,
                ProteinUnit = obj.ProteinUnit,
                GlucoseUnit = obj.GlucoseUnit,
                PuscellsUnit = obj.PuscellsUnit,
                KetonesUnit = obj.KetonesUnit,
                UrobilinogenUnit = obj.UrobilinogenUnit,
                RbcCastUnit = obj.RbcCastUnit,
                NitriteUnit = obj.NitriteUnit,
                RedBloodCellUnit = obj.RedBloodCellUnit,
                CalciumOxalateUnit = obj.CalciumOxalateUnit,
                HyalineCastUnit = obj.HyalineCastUnit,
                GranularCastUnit = obj.GranularCastUnit,
                EpithelialCellsUnit = obj.EpithelialCellsUnit,
                SpermatozoaUnit = obj.SpermatozoaUnit,
                BilirubinUnit = obj.BilirubinUnit,
                AmorphosphateUnit = obj.AmorphosphateUnit,
                TrichomonasVaginalisUnit = obj.TrichomonasVaginalisUnit,
                TriplePhosphateUnit = obj.TriplePhosphateUnit,
                UricAcidUnit = obj.UricAcidUnit,
                YeastCandidaUnit = obj.YeastCandidaUnit,
                WbcCastUnit = obj.WbcCastUnit,
                AlbuminUnit = obj.AlbuminUnit,

                BloodRefer = obj.BloodRefer,

                ClarityRefer = obj.ClarityRefer,
                OthersRefer = obj.OthersRefer,
                CrystalsRefer = obj.CrystalsRefer,
                ColourRefer = obj.ColourRefer,
                TurbidityRefer = obj.TurbidityRefer,
                SedimentRefer = obj.SedimentRefer,
                SpecificgravityRefer = obj.SpecificgravityRefer,
                PHRefer = obj.PHRefer,
                ProteinRefer = obj.ProteinRefer,
                GlucoseRefer = obj.GlucoseRefer,
                PuscellsRefer = obj.PuscellsRefer,
                KetonesRefer = obj.KetonesRefer,
                UrobilinogenRefer = obj.UrobilinogenRefer,
                RbcCastRefer = obj.RbcCastRefer,
                NitriteRefer = obj.NitriteRefer,
                RedBloodCellRefer = obj.RedBloodCellRefer,
                CalciumOxalateRefer = obj.CalciumOxalateRefer,
                HyalineCastRefer = obj.HyalineCastRefer,
                GranularCastRefer = obj.GranularCastRefer,
                EpithelialCellsRefer = obj.EpithelialCellsRefer,
                SpermatozoaRefer = obj.SpermatozoaRefer,
                BilirubinRefer = obj.BilirubinRefer,
                AmorphosphateRefer = obj.AmorphosphateRefer,
                TrichomonasVaginalisRefer = obj.TrichomonasVaginalisRefer,
                TriplePhosphateRefer = obj.TriplePhosphateRefer,
                UricAcidRefer = obj.UricAcidRefer,
                YeastCandidaRefer = obj.YeastCandidaRefer,
                WbcCastRefer = obj.WbcCastRefer,
                AlbuminRefer = obj.AlbuminRefer,
                Date = obj.Date,
                Department = obj.Department



            };
        }

        public RETestModel Create(RETest obj)
        {
            return new RETestModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                SpecimenName = obj.SpecimenName,
                ReferanceName = obj.ReferanceName,
                Clarity = obj.Clarity,
                Turbidity = obj.Turbidity,
                Sediment = obj.Sediment,
                Colour = obj.Colour,
                Specificgravity = obj.Specificgravity,
                PH = obj.PH,
                Protein = obj.Protein,
                Glucose = obj.Glucose,
                Puscells = obj.Puscells,
                Ketones = obj.Ketones,
                Urobilinogen = obj.Urobilinogen,
                RbcCast = obj.RbcCast,
                Nitrite = obj.Nitrite,
                RedBloodCell = obj.RedBloodCell,
                CalciumOxalate = obj.CalciumOxalate,
                HyalineCast = obj.HyalineCast,
                GranularCast = obj.GranularCast,
                EpithelialCells = obj.EpithelialCells,
                Spermatozoa = obj.Spermatozoa,
                Bilirubin = obj.Bilirubin,
                Amorphosphate = obj.Amorphosphate,
                TrichomonasVaginalis = obj.TrichomonasVaginalis,
                TriplePhosphate = obj.TriplePhosphate,
                UricAcid = obj.UricAcid,
                YeastCandida = obj.YeastCandida,
                WbcCast = obj.WbcCast,
                Others = obj.Others,
                Albumin = obj.Albumin,
                Date = obj.Date,
                Crystals = obj.Crystals,
                Blood = obj.Blood,
                BloodUnit = obj.BloodUnit,

                ClarityUnit = obj.ClarityUnit,
                OthersUnit = obj.OthersUnit,
                CrystalsUnit = obj.CrystalsUnit,
                ColourUnit = obj.ColourUnit,
                TurbidityUnit = obj.TurbidityUnit,
                SedimentUnit = obj.SedimentUnit,
                SpecificgravityUnit = obj.SpecificgravityUnit,
                PHUnit = obj.PHUnit,
                ProteinUnit = obj.ProteinUnit,
                GlucoseUnit = obj.GlucoseUnit,
                PuscellsUnit = obj.PuscellsUnit,
                KetonesUnit = obj.KetonesUnit,
                UrobilinogenUnit = obj.UrobilinogenUnit,
                RbcCastUnit = obj.RbcCastUnit,
                NitriteUnit = obj.NitriteUnit,
                RedBloodCellUnit = obj.RedBloodCellUnit,
                CalciumOxalateUnit = obj.CalciumOxalateUnit,
                HyalineCastUnit = obj.HyalineCastUnit,
                GranularCastUnit = obj.GranularCastUnit,
                EpithelialCellsUnit = obj.EpithelialCellsUnit,
                SpermatozoaUnit = obj.SpermatozoaUnit,
                BilirubinUnit = obj.BilirubinUnit,
                AmorphosphateUnit = obj.AmorphosphateUnit,
                TrichomonasVaginalisUnit = obj.TrichomonasVaginalisUnit,
                TriplePhosphateUnit = obj.TriplePhosphateUnit,
                UricAcidUnit = obj.UricAcidUnit,
                YeastCandidaUnit = obj.YeastCandidaUnit,
                WbcCastUnit = obj.WbcCastUnit,
                AlbuminUnit = obj.AlbuminUnit,

                BloodRefer = obj.BloodRefer,

                ClarityRefer = obj.ClarityRefer,
                OthersRefer = obj.OthersRefer,
                CrystalsRefer = obj.CrystalsRefer,
                ColourRefer = obj.ColourRefer,
                TurbidityRefer = obj.TurbidityRefer,
                SedimentRefer = obj.SedimentRefer,
                SpecificgravityRefer = obj.SpecificgravityRefer,
                PHRefer = obj.PHRefer,
                ProteinRefer = obj.ProteinRefer,
                GlucoseRefer = obj.GlucoseRefer,
                PuscellsRefer = obj.PuscellsRefer,
                KetonesRefer = obj.KetonesRefer,
                UrobilinogenRefer = obj.UrobilinogenRefer,
                RbcCastRefer = obj.RbcCastRefer,
                NitriteRefer = obj.NitriteRefer,
                RedBloodCellRefer = obj.RedBloodCellRefer,
                CalciumOxalateRefer = obj.CalciumOxalateRefer,
                HyalineCastRefer = obj.HyalineCastRefer,
                GranularCastRefer = obj.GranularCastRefer,
                EpithelialCellsRefer = obj.EpithelialCellsRefer,
                SpermatozoaRefer = obj.SpermatozoaRefer,
                BilirubinRefer = obj.BilirubinRefer,
                AmorphosphateRefer = obj.AmorphosphateRefer,
                TrichomonasVaginalisRefer = obj.TrichomonasVaginalisRefer,
                TriplePhosphateRefer = obj.TriplePhosphateRefer,
                UricAcidRefer = obj.UricAcidRefer,
                YeastCandidaRefer = obj.YeastCandidaRefer,
                WbcCastRefer = obj.WbcCastRefer,
                AlbuminRefer = obj.AlbuminRefer,
                Age = obj.Patient.Age,
                Department = obj.Department





            };
        }

        public CBCTest Create(CBCTestModel obj)
        {
            return new CBCTest
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                SpecimenName = obj.SpecimenName,
                ReferanceName = obj.ReferanceName,
                Hematocrit = obj.Hematocrit,
                Haemoglobin = obj.Haemoglobin,
                RedCellsCount = obj.RedCellsCount,
                MeanCellVolume = obj.MeanCellVolume,
                MeanCellHaemoglobin = obj.MeanCellHaemoglobin,
                MeanCellHaemoglobinConcentration = obj.MeanCellHaemoglobinConcentration,
                RedCellDistributionWidth = obj.RedCellDistributionWidth,
                NucleatedRedBloodCells = obj.NucleatedRedBloodCells,
                TotalWbcCount = obj.TotalWbcCount,
                Neutrophil = obj.Neutrophil,
                Lymphocyte = obj.Lymphocyte,
                Monocyte = obj.Monocyte,
                Eosinophil = obj.Eosinophil,
                Basophil = obj.Basophil,
                ImmatureGranulocytes = obj.ImmatureGranulocytes,
                Neutrophils = obj.Neutrophils,
                Lymphocytes = obj.Lymphocytes,
                Monocytes = obj.Monocytes,
                Eosinophils = obj.Eosinophils,
                Basophils = obj.Basophils,
                ImmatureGranulocytess = obj.ImmatureGranulocytess,
                PlateletsCount = obj.PlateletsCount,
                ErythrocyteSedimentationRate = obj.ErythrocyteSedimentationRate,
                HematocritUnit = obj.HematocritUnit,
                HaemoglobinUnit = obj.HaemoglobinUnit,
                RedCellsCountUnit = obj.RedCellsCount,
                MeanCellVolumeUnit = obj.MeanCellVolumeUnit,
                MeanCellHaemoglobinUnit = obj.MeanCellHaemoglobinUnit,
                MeanCellHaemoglobinConcentrationUnit = obj.MeanCellHaemoglobinConcentrationUnit,
                RedCellDistributionWidthUnit = obj.RedCellDistributionWidthUnit,
                NucleatedRedBloodCellsUnit = obj.NucleatedRedBloodCellsUnit,
                TotalWbcCountUnit = obj.TotalWbcCountUnit,
                NeutrophilUnit = obj.NeutrophilUnit,
                LymphocyteUnit = obj.LymphocyteUnit,
                MonocyteUnit = obj.MonocyteUnit,
                EosinophilUnit = obj.EosinophilUnit,
                BasophilUnit = obj.BasophilUnit,
                ImmatureGranulocytesUnit = obj.ImmatureGranulocytesUnit,
                NeutrophilsUnit = obj.NeutrophilsUnit,
                LymphocytesUnit = obj.LymphocytesUnit,
                MonocytesUnit = obj.MonocytesUnit,
                EosinophilsUnit = obj.EosinophilsUnit,
                BasophilsUnit = obj.BasophilsUnit,
                ImmatureGranulocytessUnit = obj.ImmatureGranulocytessUnit,
                PlateletsCountUnit = obj.PlateletsCountUnit,
                ErythrocyteSedimentationRateUnit = obj.ErythrocyteSedimentationRateUnit,
                HematocritRefer = obj.HematocritRefer,
                HaemoglobinRefer = obj.HaemoglobinRefer,
                RedCellsCountRefer = obj.RedCellsCountRefer,
                MeanCellVolumeRefer = obj.MeanCellVolumeRefer,
                MeanCellHaemoglobinRefer = obj.MeanCellHaemoglobinRefer,
                MeanCellHaemoglobinConcentrationRefer = obj.MeanCellHaemoglobinConcentrationRefer,
                RedCellDistributionWidthRefer = obj.RedCellDistributionWidthRefer,
                NucleatedRedBloodCellsRefer = obj.NucleatedRedBloodCellsRefer,
                TotalWbcCountRefer = obj.TotalWbcCountRefer,
                NeutrophilRefer = obj.NeutrophilRefer,
                LymphocyteRefer = obj.LymphocyteRefer,
                MonocyteRefer = obj.MonocyteRefer,
                EosinophilRefer = obj.EosinophilRefer,
                BasophilRefer = obj.BasophilRefer,
                ImmatureGranulocytesRefer = obj.ImmatureGranulocytesRefer,
                NeutrophilsRefer = obj.NeutrophilsRefer,
                LymphocytesRefer = obj.LymphocytesRefer,
                MonocytesRefer = obj.MonocytesRefer,
                EosinophilsRefer = obj.EosinophilsRefer,
                BasophilsRefer = obj.BasophilsRefer,
                ImmatureGranulocytessRefer = obj.ImmatureGranulocytessRefer,
                PlateletsCountRefer = obj.PlateletsCountRefer,
                ErythrocyteSedimentationRateRefer = obj.ErythrocyteSedimentationRateRefer,
                Department = obj.Department,
                Date = obj.Date,




            };
        }

        public CBCTestModel Create(CBCTest obj)
        {
            return new CBCTestModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                SpecimenName = obj.SpecimenName,
                ReferanceName = obj.ReferanceName,
                Hematocrit = obj.Hematocrit,
                Haemoglobin = obj.Haemoglobin,
                RedCellsCount = obj.RedCellsCount,
                MeanCellVolume = obj.MeanCellVolume,
                MeanCellHaemoglobin = obj.MeanCellHaemoglobin,
                MeanCellHaemoglobinConcentration = obj.MeanCellHaemoglobinConcentration,
                RedCellDistributionWidth = obj.RedCellDistributionWidth,
                NucleatedRedBloodCells = obj.NucleatedRedBloodCells,
                TotalWbcCount = obj.TotalWbcCount,
                Neutrophil = obj.Neutrophil,
                Lymphocyte = obj.Lymphocyte,
                Monocyte = obj.Monocyte,
                Eosinophil = obj.Eosinophil,
                Basophil = obj.Basophil,
                ImmatureGranulocytes = obj.ImmatureGranulocytes,
                Neutrophils = obj.Neutrophils,
                Lymphocytes = obj.Lymphocytes,
                Monocytes = obj.Monocytes,
                Eosinophils = obj.Eosinophils,
                Basophils = obj.Basophils,
                ImmatureGranulocytess = obj.ImmatureGranulocytess,
                PlateletsCount = obj.PlateletsCount,
                ErythrocyteSedimentationRate = obj.ErythrocyteSedimentationRate,
                HematocritUnit = obj.HematocritUnit,
                HaemoglobinUnit = obj.HaemoglobinUnit,
                RedCellsCountUnit = obj.RedCellsCount,
                MeanCellVolumeUnit = obj.MeanCellVolumeUnit,
                MeanCellHaemoglobinUnit = obj.MeanCellHaemoglobinUnit,
                MeanCellHaemoglobinConcentrationUnit = obj.MeanCellHaemoglobinConcentrationUnit,
                RedCellDistributionWidthUnit = obj.RedCellDistributionWidthUnit,
                NucleatedRedBloodCellsUnit = obj.NucleatedRedBloodCellsUnit,
                TotalWbcCountUnit = obj.TotalWbcCountUnit,
                NeutrophilUnit = obj.NeutrophilUnit,
                LymphocyteUnit = obj.LymphocyteUnit,
                MonocyteUnit = obj.MonocyteUnit,
                EosinophilUnit = obj.EosinophilUnit,
                BasophilUnit = obj.BasophilUnit,
                ImmatureGranulocytesUnit = obj.ImmatureGranulocytesUnit,
                NeutrophilsUnit = obj.NeutrophilsUnit,
                LymphocytesUnit = obj.LymphocytesUnit,
                MonocytesUnit = obj.MonocytesUnit,
                EosinophilsUnit = obj.EosinophilsUnit,
                BasophilsUnit = obj.BasophilsUnit,
                ImmatureGranulocytessUnit = obj.ImmatureGranulocytessUnit,
                PlateletsCountUnit = obj.PlateletsCountUnit,
                ErythrocyteSedimentationRateUnit = obj.ErythrocyteSedimentationRateUnit,
                HematocritRefer = obj.HematocritRefer,
                HaemoglobinRefer = obj.HaemoglobinRefer,
                RedCellsCountRefer = obj.RedCellsCountRefer,
                MeanCellVolumeRefer = obj.MeanCellVolumeRefer,
                MeanCellHaemoglobinRefer = obj.MeanCellHaemoglobinRefer,
                MeanCellHaemoglobinConcentrationRefer = obj.MeanCellHaemoglobinConcentrationRefer,
                RedCellDistributionWidthRefer = obj.RedCellDistributionWidthRefer,
                NucleatedRedBloodCellsRefer = obj.NucleatedRedBloodCellsRefer,
                TotalWbcCountRefer = obj.TotalWbcCountRefer,
                NeutrophilRefer = obj.NeutrophilRefer,
                LymphocyteRefer = obj.LymphocyteRefer,
                MonocyteRefer = obj.MonocyteRefer,
                EosinophilRefer = obj.EosinophilRefer,
                BasophilRefer = obj.BasophilRefer,
                ImmatureGranulocytesRefer = obj.ImmatureGranulocytesRefer,
                NeutrophilsRefer = obj.NeutrophilsRefer,
                LymphocytesRefer = obj.LymphocytesRefer,
                MonocytesRefer = obj.MonocytesRefer,
                EosinophilsRefer = obj.EosinophilsRefer,
                BasophilsRefer = obj.BasophilsRefer,
                ImmatureGranulocytessRefer = obj.ImmatureGranulocytessRefer,
                PlateletsCountRefer = obj.PlateletsCountRefer,
                ErythrocyteSedimentationRateRefer = obj.ErythrocyteSedimentationRateRefer,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date,





            };
        }
        public BioChemistry Create(BioChemistryModel obj)
        {
            return new BioChemistry
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                Potassium = obj.Potassium,
                SALT = obj.SALT,
                SCreatinine = obj.SCreatinine,
                SAlkalinePhosphatase = obj.SAlkalinePhosphatase,
                SBilirubin = obj.SBilirubin,
                Chloride = obj.Chloride,
                SAlkalinePhosphataseProteinRef = obj.SAlkalinePhosphataseProteinRef,
                PotassiumRef = obj.PotassiumRef,
                PotassiumUnit = obj.PotassiumUnit,
                SALTRef = obj.SALTRef,
                SAST = obj.SAST,
                SASTUnit = obj.SASTUnit,
                SASTRef = obj.SASTRef,
                ChlorideRef = obj.ChlorideRef,
                SAlkalinePhosphataseProteinUnit = obj.SAlkalinePhosphataseProteinUnit,
                SAlkalinePhosphataseProtein = obj.SAlkalinePhosphataseProtein,
                SBilirubinRef = obj.SBilirubinRef,
                SBilirubinUnit = obj.SBilirubinUnit,

                SCalcium = obj.SCalcium,
                SCalciumRef = obj.SCalciumRef,
                SCalciumUnit = obj.SCalciumUnit,
                BloodGlucoseRandomRef = obj.BloodGlucoseRandomRef,
                BloodGlucoseRandomUnit = obj.BloodGlucoseRandomUnit,
                SCholesterol = obj.SCholesterol,
                SCholesterolRef = obj.SCholesterolRef,
                BloodGlucoseTwohrsABFRef = obj.BloodGlucoseTwohrsABFRef,
                BloodGlucoseFastingRef = obj.BloodGlucoseFastingRef,
                SIron = obj.SIron,
                STIBC = obj.STIBC,
                TroponinI = obj.TroponinI,
                SInorganicPhosphate = obj.SInorganicPhosphate,
                SMagnesium = obj.SMagnesium,
                Sodium = obj.Sodium,
                TotalCarbondioxaid = obj.TotalCarbondioxaid,
                STriglycerides = obj.STriglycerides,
                SHDLCholesterol = obj.SHDLCholesterol,
                BloodGlucoseFastingUnit = obj.BloodGlucoseFastingUnit,

                Twohrsafter75gmGlucoseUnit = obj.Twohrsafter75gmGlucoseUnit,
                BloodGlucoseTwohrsABFUnit = obj.BloodGlucoseTwohrsABFUnit,
                UreaUnit = obj.UreaUnit,
                SAlkalinePhosphataseUnit = obj.SAlkalinePhosphataseUnit,
                SUricAcidUnit = obj.SUricAcidUnit,
                SALTUnit = obj.SALTUnit,
                SCreatinineUnit = obj.SCreatinineUnit,
                SIronUnit = obj.SIronUnit,
                STIBCUnit = obj.STIBCUnit,
                SInorganicPhosphateUnit = obj.SInorganicPhosphateUnit,
                SMagnesiumUnit = obj.SMagnesiumUnit,
                SodiumUnit = obj.SodiumUnit,
                ChlorideUnit = obj.ChlorideUnit,
                TotalCarbondioxaidUnit = obj.TotalCarbondioxaidUnit,
                SCholesterolUnit = obj.SCholesterolUnit,
                STriglyceridesUnit = obj.STriglyceridesUnit,
                SHDLCholesterolUnit = obj.SHDLCholesterolUnit,
                TroponinIUnit = obj.TroponinIUnit,
                Twohrsafter75gmGlucoseRef = obj.Twohrsafter75gmGlucoseRef,
                UreaRef = obj.UreaRef,
                SCreatinineRef = obj.SCreatinineRef,
                SIronRef = obj.SIronRef,
                STIBCRef = obj.STIBCRef,
                SInorganicPhosphateRef = obj.SInorganicPhosphateRef,
                SMagnesiumRef = obj.SMagnesiumRef,
                TotalCarbondioxaidRef = obj.TotalCarbondioxaidRef,
                STriglyceridesRef = obj.STriglyceridesRef,
                SHDLCholesterolRef = obj.SHDLCholesterolRef,
                TroponinIRef = obj.TroponinIRef,
                Department = obj.Department,

                Date = obj.Date,

            };
        }

        public BioChemistryModel Create(BioChemistry obj)
        {
            return new BioChemistryModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                Potassium = obj.Potassium,
                SALT = obj.SALT,
                SCreatinine = obj.SCreatinine,
                SAlkalinePhosphatase = obj.SAlkalinePhosphatase,
                SBilirubin = obj.SBilirubin,
                Chloride = obj.Chloride,
                SAlkalinePhosphataseProteinRef = obj.SAlkalinePhosphataseProteinRef,
                PotassiumRef = obj.PotassiumRef,
                PotassiumUnit = obj.PotassiumUnit,
                SALTRef = obj.SALTRef,
                SAST = obj.SAST,
                TroponinI = obj.TroponinI,
                SASTUnit = obj.SASTUnit,
                SASTRef = obj.SASTRef,
                ChlorideRef = obj.ChlorideRef,
                SAlkalinePhosphataseProteinUnit = obj.SAlkalinePhosphataseProteinUnit,
                SAlkalinePhosphataseProtein = obj.SAlkalinePhosphataseProtein,
                SBilirubinRef = obj.SBilirubinRef,
                SBilirubinUnit = obj.SBilirubinUnit,

                SCalcium = obj.SCalcium,
                SCalciumRef = obj.SCalciumRef,
                SCalciumUnit = obj.SCalciumUnit,
                BloodGlucoseRandomRef = obj.BloodGlucoseRandomRef,
                BloodGlucoseRandomUnit = obj.BloodGlucoseRandomUnit,
                SCholesterol = obj.SCholesterol,
                SCholesterolRef = obj.SCholesterolRef,
                BloodGlucoseTwohrsABFRef = obj.BloodGlucoseTwohrsABFRef,
                BloodGlucoseFastingRef = obj.BloodGlucoseFastingRef,
                SIron = obj.SIron,
                STIBC = obj.STIBC,
                SInorganicPhosphate = obj.SInorganicPhosphate,
                SMagnesium = obj.SMagnesium,
                Sodium = obj.Sodium,
                TotalCarbondioxaid = obj.TotalCarbondioxaid,
                STriglycerides = obj.STriglycerides,
                SHDLCholesterol = obj.SHDLCholesterol,
                BloodGlucoseFastingUnit = obj.BloodGlucoseFastingUnit,

                Twohrsafter75gmGlucoseUnit = obj.Twohrsafter75gmGlucoseUnit,
                BloodGlucoseTwohrsABFUnit = obj.BloodGlucoseTwohrsABFUnit,
                UreaUnit = obj.UreaUnit,
                SAlkalinePhosphataseUnit = obj.SAlkalinePhosphataseUnit,
                SUricAcidUnit = obj.SUricAcidUnit,
                SALTUnit = obj.SALTUnit,
                SCreatinineUnit = obj.SCreatinineUnit,
                SIronUnit = obj.SIronUnit,
                STIBCUnit = obj.STIBCUnit,
                SInorganicPhosphateUnit = obj.SInorganicPhosphateUnit,
                SMagnesiumUnit = obj.SMagnesiumUnit,
                SodiumUnit = obj.SodiumUnit,
                ChlorideUnit = obj.ChlorideUnit,
                TotalCarbondioxaidUnit = obj.TotalCarbondioxaidUnit,
                SCholesterolUnit = obj.SCholesterolUnit,
                STriglyceridesUnit = obj.STriglyceridesUnit,
                SHDLCholesterolUnit = obj.SHDLCholesterolUnit,
                TroponinIUnit = obj.TroponinIUnit,
                Twohrsafter75gmGlucoseRef = obj.Twohrsafter75gmGlucoseRef,
                UreaRef = obj.UreaRef,
                SCreatinineRef = obj.SCreatinineRef,
                SIronRef = obj.SIronRef,
                STIBCRef = obj.STIBCRef,
                SInorganicPhosphateRef = obj.SInorganicPhosphateRef,
                SMagnesiumRef = obj.SMagnesiumRef,
                TotalCarbondioxaidRef = obj.TotalCarbondioxaidRef,
                STriglyceridesRef = obj.STriglyceridesRef,
                SHDLCholesterolRef = obj.SHDLCholesterolRef,
                TroponinIRef = obj.TroponinIRef,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date



            };
        }

        public IMMUNOLOGICAL Create(IMMUNOLOGICALModel obj)
        {
            return new IMMUNOLOGICAL
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                SFerritin = obj.SFerritin,
                TIgE = obj.TIgE,
                βhCG = obj.βhCG,
                PSA = obj.PSA,
                TIgERef = obj.TIgERef,
                SFerritinRef = obj.SFerritinRef,
                TIgEUnit = obj.TIgEUnit,
                PSARef = obj.PSARef,
                PSAUnit = obj.PSAUnit,
                SFerritinUnit = obj.SFerritinUnit,
                βhCGRef = obj.βhCGRef,
                βhCGUnit = obj.βhCGUnit,
                Department = obj.Department,

                Date = obj.Date

            };
        }
        public IMMUNOLOGICALModel Create(IMMUNOLOGICAL obj)
        {
            return new IMMUNOLOGICALModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                SFerritin = obj.SFerritin,
                TIgE = obj.TIgE,
                βhCG = obj.βhCG,
                PSA = obj.PSA,
                TIgERef = obj.TIgERef,
                SFerritinRef = obj.SFerritinRef,
                TIgEUnit = obj.TIgEUnit,
                PSARef = obj.PSARef,
                PSAUnit = obj.PSAUnit,
                SFerritinUnit = obj.SFerritinUnit,
                βhCGRef = obj.βhCGRef,
                βhCGUnit = obj.βhCGUnit,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date,

            };
        }

        public SEROLOGY Create(SEROLOGYModel obj)
        {
            return new SEROLOGY
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                CRP = obj.CRP,
                RA = obj.RA,
                ASO = obj.ASO,
                HBsAg = obj.HBsAg,
                BloodGroup = obj.BloodGroup,
                RhFactor = obj.RhFactor,
                UrineforPregnancyTest = obj.UrineforPregnancyTest,
                VDRL = obj.VDRL,
                TO = obj.TO,
                TH = obj.TH,
                AH = obj.AH,
                BH = obj.BH,
                AO = obj.AO,
                BO = obj.BO,
                CRPRef = obj.CRPRef,
                RARef = obj.RARef,
                ASORef = obj.ASORef,
                HBsAgRef = obj.HBsAgRef,
                BloodGroupRef = obj.BloodGroupRef,
                RhFactorRef = obj.RhFactor,
                UrineforPregnancyTestRef = obj.UrineforPregnancyTestRef,
                VDRLRef = obj.VDRLRef,
                TORef = obj.TORef,
                THRef = obj.THRef,
                AHRef = obj.AHRef,
                BHRef = obj.BHRef,
                AORef = obj.AORef,
                BORef = obj.BORef,
                CRPUnit = obj.CRPUnit,
                RAUnit = obj.RAUnit,
                ASOUnit = obj.ASOUnit,
                HBsAgUnit = obj.HBsAgUnit,
                BloodGroupUnit = obj.BloodGroupUnit,
                RhFactorUnit = obj.RhFactorUnit,
                UrineforPregnancyTestUnit = obj.UrineforPregnancyTestUnit,
                VDRLUnit = obj.VDRLUnit,
                TOUnit = obj.TOUnit,
                THUnit = obj.THUnit,
                AHUnit = obj.AHUnit,
                BHUnit = obj.BHUnit,
                AOUnit = obj.AOUnit,
                BOUnit = obj.BOUnit,
                Department = obj.Department,

                Date = obj.Date,


            };
        }

        public SEROLOGYModel Create(SEROLOGY obj)
        {
            return new SEROLOGYModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientName = obj.Patient.Name,
                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                CRP = obj.CRP,
                RA = obj.RA,
                ASO = obj.ASO,
                HBsAg = obj.HBsAg,
                BloodGroup = obj.BloodGroup,
                RhFactor = obj.RhFactor,
                UrineforPregnancyTest = obj.UrineforPregnancyTest,
                VDRL = obj.VDRL,
                TO = obj.TO,
                TH = obj.TH,
                AH = obj.AH,
                BH = obj.BH,
                AO = obj.AO,
                BO = obj.BO,
                CRPRef = obj.CRPRef,
                RARef = obj.RARef,
                ASORef = obj.ASORef,
                HBsAgRef = obj.HBsAgRef,
                BloodGroupRef = obj.BloodGroupRef,
                RhFactorRef = obj.RhFactor,
                UrineforPregnancyTestRef = obj.UrineforPregnancyTestRef,
                VDRLRef = obj.VDRLRef,
                TORef = obj.TORef,
                THRef = obj.THRef,
                AHRef = obj.AHRef,
                BHRef = obj.BHRef,
                AORef = obj.AORef,
                BORef = obj.BORef,
                CRPUnit = obj.CRPUnit,
                RAUnit = obj.RAUnit,
                ASOUnit = obj.ASOUnit,
                HBsAgUnit = obj.HBsAgUnit,
                BloodGroupUnit = obj.BloodGroupUnit,
                RhFactorUnit = obj.RhFactorUnit,
                UrineforPregnancyTestUnit = obj.UrineforPregnancyTestUnit,
                VDRLUnit = obj.VDRLUnit,
                TOUnit = obj.TOUnit,
                THUnit = obj.THUnit,
                AHUnit = obj.AHUnit,
                BHUnit = obj.BHUnit,
                AOUnit = obj.AOUnit,
                BOUnit = obj.BOUnit,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date,


            };
        }

        public ENDOCRINOLOGY Create(ENDOCRINOLOGYModel obj)
        {
            return new ENDOCRINOLOGY
            {
                Id = obj.Id,
                PatientId = obj.PatientId,

                PatientCode = obj.PatientCode,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                LH = obj.LH,
                T3 = obj.T3,
                T4 = obj.T4,
                TSH = obj.TSH,
                FreeT3 = obj.FreeT3,
                FreeT4 = obj.FreeT4,
                FSH = obj.FSH,
                Prolactin = obj.Prolactin,
                STestosterone = obj.STestosterone,
                T3Unit = obj.T3Unit,
                T4Unit = obj.T4Unit,
                TSHUnit = obj.TSHUnit,
                FreeT3Unit = obj.FreeT3Unit,
                FreeT4Unit = obj.FreeT4Unit,
                FSHUnit = obj.FSHUnit,
                ProlactinUnit = obj.ProlactinUnit,
                STestosteroneUnit = obj.STestosteroneUnit,
                LHUnit = obj.LHUnit,
                LHRef = obj.LHRef,
                T3Ref = obj.T3Ref,
                T4Ref = obj.T4Ref,
                TSHRef = obj.TSHRef,
                FreeT3Ref = obj.FreeT3Ref,
                FreeT4Ref = obj.FreeT4Ref,
                FSHRef = obj.FSHRef,
                ProlactinRef = obj.ProlactinRef,
                STestosteroneRef = obj.STestosteroneRef,
                Department = obj.Department,

                Date = obj.Date,


            };
        }

        public ENDOCRINOLOGYModel Create(ENDOCRINOLOGY obj)
        {
            return new ENDOCRINOLOGYModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,

                PatientCode = obj.PatientCode,
                PatientName = obj.Patient.Name,
                ReferanceName = obj.ReferanceName,
                SpecimenName = obj.SpecimenName,
                LH = obj.LH,
                T3 = obj.T3,
                T4 = obj.T4,
                TSH = obj.TSH,
                FreeT3 = obj.FreeT3,
                FreeT4 = obj.FreeT4,
                FSH = obj.FSH,
                Prolactin = obj.Prolactin,
                STestosterone = obj.STestosterone,
                T3Unit = obj.T3Unit,
                T4Unit = obj.T4Unit,
                TSHUnit = obj.TSHUnit,
                FreeT3Unit = obj.FreeT3Unit,
                FreeT4Unit = obj.FreeT4Unit,
                FSHUnit = obj.FSHUnit,
                ProlactinUnit = obj.ProlactinUnit,
                STestosteroneUnit = obj.STestosteroneUnit,
                LHUnit = obj.LHUnit,
                LHRef = obj.LHRef,
                T3Ref = obj.T3Ref,
                T4Ref = obj.T4Ref,
                TSHRef = obj.TSHRef,
                FreeT3Ref = obj.FreeT3Ref,
                FreeT4Ref = obj.FreeT4Ref,
                FSHRef = obj.FSHRef,
                ProlactinRef = obj.ProlactinRef,
                STestosteroneRef = obj.STestosteroneRef,
                Department = obj.Department,
                Age = obj.Patient.Age,
                Date = obj.Date,


            };
        }
        public Specimen Create(SpecimenModel obj)
        {
            return new Specimen
            {
                Id = obj.Id,
                Name = obj.Name,


            };
        }

        public SpecimenModel Create(Specimen obj)
        {
            return new SpecimenModel
            {
                Id = obj.Id,
                Name = obj.Name,



            };
        }




        public LabItemModel Create(LabItem obj)
        {
            return new LabItemModel
            {
                Id = obj.Id,
                Name = obj.Name,
                PackageSize = obj.PackageSize,
                RewardedLevel = obj.RewardedLevel

            };
        }

        public LabItem Create(LabItemModel obj)
        {
            return new LabItem
            {
                Id = obj.Id,
                Name = obj.Name,
                PackageSize = obj.PackageSize,
                RewardedLevel = obj.RewardedLevel

            };
        }
        public StoreItemModel Create(StoreItem obj)
        {
            return new StoreItemModel
            {
                Id = obj.Id,
                ItemName = obj.ItemName,
                StoreItemCategoryId = obj.StoreItemCategoryId,
                ReOrderLevel = obj.ReOrderLevel,
                CategoryName = obj.CategoryName,
                Description = obj.Description,
                Department = obj.Department

            };
        }

        public StoreItem Create(StoreItemModel obj)
        {
            return new StoreItem
            {
                Id = obj.Id,
                ItemName = obj.ItemName,
                StoreItemCategoryId = obj.StoreItemCategoryId,
                ReOrderLevel = obj.ReOrderLevel,
                CategoryName = obj.CategoryName,
                Description = obj.Description,
                Department = obj.Department

            };
        }

        public StoreItemCategory Create(StoreItemCategoryModel obj)
        {
            return new StoreItemCategory
            {
                Id = obj.Id,
                Name = obj.Name

            };
        }

        public StoreItemCategoryModel Create(StoreItemCategory obj)
        {
            return new StoreItemCategoryModel
            {
                Id = obj.Id,

                Name = obj.Name
            };
        }


        public OperationTypeModel Create(OperationType obj)
        {
            return new OperationTypeModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,

            };
        }

        public OperationType Create(OperationTypeModel obj)
        {
            return new OperationType
            {
                Id = obj.Id,
                Name = obj.Name,
                Price = obj.Price,
            };
        }



        public Ward Create(WardModel obj)
        {
            return new Ward
            {
                Id = obj.Id,
                Name = obj.Name,
                //WardTypeId = obj.WardTypeId,
                Description = obj.Description,
                PriceByDay = obj.PriceByDay

            };
        }

        public WardModel Create(Ward obj)
        {
            return new WardModel
            {
                Id = obj.Id,
                Name = obj.Name,
                //WardTypeId = obj.WardTypeId,
                //WardTypeName = obj.WardType.Name,
                Description = obj.Description,
                PriceByDay = obj.PriceByDay,
                BedModels = obj.Beds.Select(Create).ToList()
            };
        }



        public Bed Create(BedModel obj)
        {
            return new Bed
            {
                Id = obj.Id,
                Name = obj.Name,
                WardId = obj.WardId,
                Description = obj.Description,
                Price = obj.Price

            };
        }

        public BedModel Create(Bed obj)
        {
            return new BedModel
            {
                Id = obj.Id,
                Name = obj.Name,
                WardId = obj.WardId,
                WardName = obj.Ward.Name,
                Description = obj.Description,
                Price = obj.Price

            };
        }

        public WardType Create(WardTypeModel obj)
        {
            return new WardType
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status
            };
        }
        public WardTypeModel Create(WardType obj)
        {
            return new WardTypeModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status,
                //WardModels = obj.Wards.Select(Create).ToList()

            };
        }
        public AppAppointmentSystemUser Create(AppAppointmentSystemUserModel obj)
        {
            return new AppAppointmentSystemUser
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                EmployeeId = obj.EmployeeId
            };
        }

        public AppAppointmentSystemUserModel Create(AppAppointmentSystemUser obj)
        {
            return new AppAppointmentSystemUserModel
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                HospitalName = obj.HospitalInformation.Name,
                EmployeeId = obj.EmployeeId,
                EmployeeName = obj.Employee.FirstName,
                AspNetUserId = obj.AspNetUser.Id
            };
        }

        public AppMedicineCornerUser Create(AppMedicineCornerUserModel obj)
        {
            return new AppMedicineCornerUser
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                EmployeeId = obj.EmployeeId
            };
        }

        public AppMedicineCornerUserModel Create(AppMedicineCornerUser obj)
        {
            return new AppMedicineCornerUserModel
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                HospitalName = obj.HospitalInformation.Name,
                EmployeeId = obj.EmployeeId,
                EmployeeName = obj.Employee.FirstName,
                AspNetUserId = obj.AspNetUser.Id
            };
        }


        public AppPatientManagementUser Create(AppPatientManagementUserModel obj)
        {
            return new AppPatientManagementUser
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                DoctorId = obj.DoctorId,
                EmployeeId = obj.EmployeeId
            };
        }

        public AppPatientManagementUserModel Create(AppPatientManagementUser obj)
        {
            return new AppPatientManagementUserModel
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                ApplicationUserName = obj.AspNetUser.UserName,
                HospitalId = obj.HospitalId,
                HospitalName = obj.HospitalInformation.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                EmployeeId = obj.EmployeeId,
                EmployeeName = obj.Employee.FirstName,
                AspNetUserId = obj.AspNetUser.Id
            };
        }

        public AppUser Create(AppUserModel obj)
        {
            return new AppUser
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                Pharmacy = obj.Pharmacy,
                Appointment = obj.Appointment,
                PatientManagement = obj.PatientManagement,
                Pathology = obj.Pathology
            };
        }

        public AppUserModel Create(AppUser obj)
        {
            return new AppUserModel
            {
                Id = obj.Id,
                ApplicationUserId = obj.ApplicationUserId,
                HospitalId = obj.HospitalId,
                Pharmacy = obj.Pharmacy,
                Appointment = obj.Appointment,
                PatientManagement = obj.PatientManagement,
                Pathology = obj.Pathology
            };
        }

        public AllergyInformationModel Create(AllergyInformation obj)
        {
            return new AllergyInformationModel
            {
                Id = obj.Id,
                Title = obj.Title,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public AllergyInformation Create(AllergyInformationModel obj)
        {
            return new AllergyInformation
            {
                Id = obj.Id,
                Title = obj.Title,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public AllergySubstanceModel Create(AllergySubstance obj)
        {
            return new AllergySubstanceModel
            {
                Id = obj.Id,
                AllergyInformationId = obj.AllergyInformationId,
                Details = obj.Details,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate


            };
        }

        public AllergySubstance Create(AllergySubstanceModel obj)
        {
            return new AllergySubstance
            {
                Id = obj.Id,
                AllergyInformationId = obj.AllergyInformationId,
                Details = obj.Details,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }
        public DoctorAppointment Create(DoctorAppointmentModel obj)
        {
            return new DoctorAppointment
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                Date = obj.Date,
                PatientId = obj.PatientId,
                Time = obj.Time,
                PatientType = obj.PatientType,
                AppointmentType = obj.AppointmentType,

                MobileNo = obj.MobileNo,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DoctorAppointmentModel Create(DoctorAppointment obj)
        {
            return new DoctorAppointmentModel
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                Date = obj.Date,
                PatientId = obj.PatientId,
                PatientName = obj.PatientName,
                Time = obj.Time,
                PatientType = obj.PatientType,
                AppointmentType = obj.AppointmentType,

                MobileNo = obj.MobileNo,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DoctorAppointmentPaymentModel Create(DoctorAppointmentPayment obj)
        {
            return new DoctorAppointmentPaymentModel
            {
                Id = obj.Id,
                PatientEnrollId = obj.PatientEnrollId,
                VisitNo = obj.VisitNo,
                MsAmountPurposeId = obj.MsAmountPurposeId,
                AmountPurposeDescription = obj.MsAmountPurpose.Description,
                Amount = obj.Amount,
                Discount = obj.Discount,
                Reason = obj.Reason,
                Voucher = obj.Voucher,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DoctorAppointmentPayment Create(DoctorAppointmentPaymentModel obj)
        {
            return new DoctorAppointmentPayment
            {
                Id = obj.Id,
                PatientEnrollId = obj.PatientEnrollId,
                VisitNo = obj.VisitNo,
                MsAmountPurposeId = obj.MsAmountPurposeId,
                Amount = obj.Amount,
                Discount = obj.Discount,
                Reason = obj.Reason,
                Voucher = obj.Voucher,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DoctorBusinessHolidayModel Create(DoctorBusinessHoliday obj)
        {
            return new DoctorBusinessHolidayModel
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                Title = obj.Title,
                Date = obj.Date,
                SpecificDate = obj.SpecificDate,
                DayOfTheWeek = obj.DayOfTheWeek,
                DayOfTheMonth = obj.DayOfTheMonth,
                DayOfTheYear = obj.DayOfTheYear,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate


            };
        }

        public DoctorBusinessHoliday Create(DoctorBusinessHolidayModel obj)
        {
            return new DoctorBusinessHoliday
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,

                Title = obj.Title,
                Date = obj.Date,
                SpecificDate = obj.SpecificDate,
                DayOfTheWeek = obj.DayOfTheWeek,
                DayOfTheMonth = obj.DayOfTheMonth,
                DayOfTheYear = obj.DayOfTheYear,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate


            };
        }


        public DoctorInformationModel Create(DoctorInformation obj)
        {
            return new DoctorInformationModel
            {
                Id = obj.Id,
                Name = obj.Name,
                HospitalId = obj.HospitalId,
                ShiftId = obj.ShiftId,
                Badgenumber = obj.Badgenumber,
                Degree = obj.Degree,
                License = obj.License,
                Image = obj.Image,
                Speciality = obj.Speciality,
                OfficeAddress = obj.OfficeAddress,
                OfficePhone = obj.OfficePhone,
                ChamberAddress = obj.ChamberAddress,
                ChamberPhone = obj.ChamberPhone,
                MobileNumber = obj.MobileNumber,
                Email = obj.Email,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,

                AppPatientManagementUserModels = obj.AppPatientManagementUsers.Select(Create).ToList(),
                DoctorAppointmentModels = obj.DoctorAppointments.Select(Create).ToList(),
                PatientHistorieModels = obj.PatientHistories.Select(Create).ToList(),
                PatientPrescriptionodels = obj.PatientPrescriptions.Select(Create).ToList(),
                PatientEnrollModels = obj.PatientEnrolls.Select(Create).ToList(),
                DoctorBusinessHolidayMOdels = obj.DoctorBusinessHolidays.Select(Create).ToList(),
                DoctorBusinessHoursModels = obj.DoctorBusinessHours.Select(Create).ToList(),
                MsAmountPurposeModels = obj.MsAmountPurposes.Select(Create).ToList(),
                VisitDiscountModels = obj.VisitDiscounts.Select(Create).ToList(),
                OperationNoteModels = obj.OperationNote.Select(Create).ToList()
            };
        }

        public DoctorInformation Create(DoctorInformationModel obj)
        {
            return new DoctorInformation
            {
                Id = obj.Id,
                Name = obj.Name,
                HospitalId = obj.HospitalId,
                ShiftId = obj.ShiftId,
                Badgenumber = obj.Badgenumber,
                Degree = obj.Degree,
                License = obj.License,
                Image = obj.Image,
                Speciality = obj.Speciality,
                OfficeAddress = obj.OfficeAddress,
                OfficePhone = obj.OfficePhone,
                ChamberAddress = obj.ChamberAddress,
                ChamberPhone = obj.ChamberPhone,
                MobileNumber = obj.MobileNumber,
                Email = obj.Email,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }



        public DoctorBusinessHour Create(DoctorBusinessHourModel obj)
        {
            return new DoctorBusinessHour
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                WeekDay = obj.WeekDay,
                FromTime = obj.FromTime,
                ToTime = obj.ToTime,
                Status = obj.Status
            };
        }

        public DoctorBusinessHourModel Create(DoctorBusinessHour obj)
        {
            return new DoctorBusinessHourModel
            {
                Id = obj.Id,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                WeekDay = obj.WeekDay,
                FromTime = obj.FromTime,
                ToTime = obj.ToTime,
                Status = obj.Status
            };
        }
        public DoctorNoteModel Create(DoctorNote obj)
        {
            return new DoctorNoteModel
            {
                Id = obj.Id,
                Note = obj.Note,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DoctorNote Create(DoctorNoteModel obj)
        {
            return new DoctorNote
            {
                Id = obj.Id,
                Note = obj.Note,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public VisitDiscountModel Create(VisitDiscount obj)
        {
            return new VisitDiscountModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientName = obj.PatientInformation.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                DiscountAmount = obj.DiscountAmount,
                Date = obj.Date,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public VisitDiscount Create(VisitDiscountModel obj)
        {
            return new VisitDiscount
            {
                Id = obj.Id,
                PatientId = obj.PatientId,

                DoctorId = obj.DoctorId,

                DiscountAmount = obj.DiscountAmount,
                Date = obj.Date,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public HospitalInformationModel Create(HospitalInformation obj)
        {
            return new HospitalInformationModel
            {
                Id = obj.Id,
                Name = obj.Name,
                ContactPersonName = obj.ContactPersonName,
                ContactPersonMobile = obj.ContactPersonMobile,
                Address = obj.Address,
                Mobile = obj.Mobile,
                Telephone = obj.Telephone,
                Email = obj.Email,
                Logo = obj.Logo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }
        public HospitalInformation Create(HospitalInformationModel obj)
        {
            return new HospitalInformation
            {
                Id = obj.Id,
                Name = obj.Name,
                ContactPersonName = obj.ContactPersonName,
                ContactPersonMobile = obj.ContactPersonMobile,
                Address = obj.Address,
                Mobile = obj.Mobile,
                Telephone = obj.Telephone,
                Email = obj.Email,
                Logo = obj.Logo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }


        public Cabin Create(CabinModel obj)
        {
            return new Cabin
            {
                Id = obj.Id,
                Name = obj.Name,
                CabinTypeId = obj.CabinTypeId,
                Description = obj.Description,
                PriceByDay = obj.PriceByDay

            };
        }

        public CabinModel Create(Cabin obj)
        {
            return new CabinModel
            {
                Id = obj.Id,
                Name = obj.Name,
                CabinTypeId = obj.CabinTypeId,
                CabinTypeName = obj.CabinType.Name,
                Description = obj.Description,
                PriceByDay = obj.PriceByDay

            };
        }



        public CabinType Create(CabinTypeModel obj)
        {
            return new CabinType
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status

            };
        }

        public CabinTypeModel Create(CabinType obj)
        {
            return new CabinTypeModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status,
                CabinModels = obj.Cabins.Select(Create).ToList()
            };
        }
        public CabinRent Create(CabinRentModel obj)
        {
            return new CabinRent
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                AdmissionNo = obj.AdmissionNo,
                EmergencyContactPerson = obj.EmergencyContactPerson,
                Duration = obj.Duration,
                MobileNo = obj.MobileNo,
                Rate = obj.Rate,
                TotalPrice = obj.TotalPrice,
                RentDate = obj.RentDate,
                DischargeDate = obj.DischargeDate,

            };
        }

        public CabinRentModel Create(CabinRent obj)
        {
            return new CabinRentModel
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                CabinName = obj.Cabin.Name,
                PatientId = obj.PatientId,
                PatientCode = obj.PatientCode,
                AdmissionNo = obj.AdmissionNo,
                PatientName = obj.PatientInformation.Name,
                EmergencyContactPerson = obj.EmergencyContactPerson,
                Duration = obj.Duration,
                MobileNo = obj.MobileNo,
                Rate = obj.Rate,
                TotalPrice = obj.TotalPrice,
                RentDate = obj.RentDate,
                DischargeDate = obj.DischargeDate,
            };
        }
        public CabinAmenity Create(CabinAmenityModel obj)
        {
            return new CabinAmenity
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                AmenityId = obj.AmenityId,
                Status = obj.Status,



            };
        }

        public CabinAmenityModel Create(CabinAmenity obj)
        {
            return new CabinAmenityModel
            {
                Id = obj.Id,
                CabinId = obj.CabinId,
                CabinName = obj.Cabin.Name,
                AmenityId = obj.AmenityId,
                AmenityName = obj.Amenity.Name,
                Status = obj.Status,
            };
        }
        public DiseaseConditionModel Create(DiseaseCondition obj)
        {
            return new DiseaseConditionModel
            {
                Id = obj.Id,
                Description = obj.Description,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DiseaseCondition Create(DiseaseConditionModel obj)
        {
            return new DiseaseCondition
            {
                Id = obj.Id,
                Description = obj.Description,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public DiseaseModel Create(Disease obj)
        {
            return new DiseaseModel
            {
                MD_ID = obj.MD_ID,
                MD_NAME = obj.MD_NAME,

                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public Disease Create(DiseaseModel obj)
        {
            return new Disease
            {
                MD_ID = obj.MD_ID,
                MD_NAME = obj.MD_NAME,

                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }

        public EducationModel Create(Education obj)
        {
            return new EducationModel
            {
                Id = obj.Id,
                EmployeeInfoId = obj.EmployeeInfoId,
                EmployeeName = obj.EmployeeInfo.FirstName,
                DegreeName = obj.DegreeName,
                Grade = obj.Grade,
                Institution = obj.Institution,
                CourseDuration = obj.CourseDuration,
                Year = obj.Year,
                Scale = obj.Scale,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,


            };
        }

        public Education Create(EducationModel obj)
        {
            return new Education
            {
                Id = obj.Id,
                DegreeName = obj.DegreeName,
                Grade = obj.Grade,
                Institution = obj.Institution,
                CourseDuration = obj.CourseDuration,
                Year = obj.Year,
                Scale = obj.Scale,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public EmergencyContact Create(EmergencyContactModel obj)
        {
            return new EmergencyContact
            {
                Id = obj.Id,
                EmployeeInfoId = obj.EmployeeInfoId,
                RefferenceId = obj.RefferenceId,
                ContactName1 = obj.ContactName1,
                Relationship1 = obj.Relationship1,
                Address1 = obj.Address1,
                Homephone1 = obj.Homephone1,
                Workphone1 = obj.Workphone1,
                Cellphone1 = obj.Cellphone1,
                ContactName2 = obj.ContactName2,
                Relationship2 = obj.Relationship2,
                Address2 = obj.Address2,
                Homephone2 = obj.Homephone2,
                Workphone2 = obj.Workphone2,
                Cellphone2 = obj.Cellphone2,
                PhysicianName = obj.PhysicianName,
                PhysicianAddress = obj.PhysicianAddress,
                PhysicianContactNo = obj.PhysicianContactNo,

                RefferenceType = obj.RefferenceType

            };
        }
        public EmergencyContactModel Create(EmergencyContact obj)
        {
            return new EmergencyContactModel
            {
                Id = obj.Id,
                EmployeeInfoId = obj.EmployeeInfoId,
                EmployeeName = obj.EmployeeInfo.FirstName,
                RefferenceId = obj.RefferenceId,
                ContactName1 = obj.ContactName1,
                Relationship1 = obj.Relationship1,
                Address1 = obj.Address1,
                Homephone1 = obj.Homephone1,
                Workphone1 = obj.Workphone1,
                Cellphone1 = obj.Cellphone1,
                ContactName2 = obj.ContactName2,
                Relationship2 = obj.Relationship2,
                Address2 = obj.Address2,
                Homephone2 = obj.Homephone2,
                Workphone2 = obj.Workphone2,
                Cellphone2 = obj.Cellphone2,
                PhysicianName = obj.PhysicianName,
                PhysicianAddress = obj.PhysicianAddress,
                PhysicianContactNo = obj.PhysicianContactNo,

                RefferenceType = obj.RefferenceType

            };
        }

        public LC Create(LcModel obj)
        {
            return new LC
            {
                Id = obj.Id,
                LCNo = obj.LCNo,
                IssueDate = obj.IssueDate,
                BeneficiayName = obj.BeneficiayName,
                Origin = obj.Origin,
                Item = obj.Item,
                LCValue = obj.LCValue,
                CurrencyTypeId = obj.CurrencyTypeId,
                Quantity = obj.Quantity,
                Tenor = obj.Tenor,
                Port = obj.Port,
                InvoiceNo = obj.InvoiceNo,
                InvoiceValue = obj.InvoiceValue,
                InvoiceCurrencyTypeId = obj.InvoiceCurrencyTypeId,
                ShipDate = obj.ShipDate,
                ShipQty = obj.ShipQty,
                ETA = obj.ETA,
                PaidOn = obj.PaidOn,
                BLNo = obj.BLNo,
                UPassDue = obj.UPassDue,
                Rmks = obj.Rmks

            };
        }
        public LcModel Create(LC obj)
        {
            return new LcModel
            {
                Id = obj.Id,
                LCNo = obj.LCNo,
                IssueDate = obj.IssueDate,
                BeneficiayName = obj.BeneficiayName,
                Origin = obj.Origin,
                Item = obj.Item,
                LCValue = obj.LCValue,
                CurrencyTypeId = obj.CurrencyTypeId,
                Quantity = obj.Quantity,
                Tenor = obj.Tenor,
                Port = obj.Port,
                InvoiceNo = obj.InvoiceNo,
                InvoiceValue = obj.InvoiceValue,
                InvoiceCurrencyTypeId = obj.InvoiceCurrencyTypeId,
                ShipDate = obj.ShipDate,
                ShipQty = obj.ShipQty,
                ETA = obj.ETA,
                PaidOn = obj.PaidOn,
                BLNo = obj.BLNo,
                UPassDue = obj.UPassDue,
                Rmks = obj.Rmks

            };
        }


        public FamilyTreeModel Create(FamilyTree obj)
        {
            return new FamilyTreeModel
            {
                Id = obj.Id,
                Title = obj.Title,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public FamilyTree Create(FamilyTreeModel obj)
        {
            return new FamilyTree
            {
                Id = obj.Id,
                Title = obj.Title,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public MsAmountPurposeModel Create(MsAmountPurpose obj)
        {
            return new MsAmountPurposeModel
            {
                Id = obj.Id,
                Description = obj.Description,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                Amount = obj.Amount,
                Type = obj.Type,
                RecStatus = obj.RecStatus,

                IpAddress = obj.IpAddress,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public MsAmountPurpose Create(MsAmountPurposeModel obj)
        {
            return new MsAmountPurpose
            {
                Id = obj.Id,
                Description = obj.Description,
                DoctorId = obj.DoctorId,

                Amount = obj.Amount,
                Type = obj.Type,
                RecStatus = obj.RecStatus,

                IpAddress = obj.IpAddress,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public OccupationModel Create(Occupation obj)
        {
            return new OccupationModel
            {
                Name = obj.Name,
                Id = obj.Id,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public Occupation Create(OccupationModel obj)
        {
            return new Occupation
            {
                Name = obj.Name,
                Id = obj.Id,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

            };
        }

        public SocialEconomicStatusModel Create(SocialEconomicStatus obj)
        {
            return new SocialEconomicStatusModel
            {
                Id = obj.Id,
                Details = obj.Details,

            };

        }


        public SocialEconomicStatus Create(SocialEconomicStatusModel obj)
        {
            return new SocialEconomicStatus
            {
                Id = obj.Id,
                Details = obj.Details,

            };

        }

        public SpecialNote Create(SpecialNoteModel obj)
        {
            return new SpecialNote
            {
                Id = obj.Id,
                Note = obj.Note
            };
        }

        public SpecialNoteModel Create(SpecialNote obj)
        {
            return new SpecialNoteModel
            {
                Id = obj.Id,
                Note = obj.Note
            };
        }

        public DrugSaleDetails Create(DrugSaleDetailsModel obj)
        {
            return new DrugSaleDetails
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugSaleId = obj.DrugSaleId,
                Quantity = obj.Quantity,
                SaleDiscount = obj.SaleDiscount,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total
            };
        }

        public DrugSaleDetailsHistoryModel Create(DrugSaleDetailsHistory obj)
        {
            return new DrugSaleDetailsHistoryModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugSaleHistoryId = obj.DrugSaleHistoryId,
                Quantity = obj.Quantity,
                SaleDiscount = obj.SaleDiscount,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total,
                DrugName = obj.Drug.D_TRADE_NAME,

            };
        }
        public DrugSaleHistory Create(DrugSaleHistoryModel obj)
        {
            return new DrugSaleHistory
            {
                Id = obj.Id,
                LotId = obj.LotId,

                MemoNo = obj.MemoNo,
                SaleDateTime = obj.SaleDateTime,
                SalePrice = obj.SalePrice,
                SaleQty = obj.SaleQty,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TxnNo = obj.TxnNo,
                Amount = obj.Amount,
                Vat = obj.Vat,
                PatientId = obj.PatientId,

            };
        }

        public DrugSaleHistoryModel Create(DrugSaleHistory obj)
        {
            return new DrugSaleHistoryModel
            {
                Id = obj.Id,
                LotId = obj.LotId,

                MemoNo = obj.MemoNo,
                SaleDateTime = obj.SaleDateTime,
                SalePrice = obj.SalePrice,
                SaleQty = obj.SaleQty,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TxnNo = obj.TxnNo,
                Amount = obj.Amount,
                Vat = obj.Vat,
                PatientId = obj.PatientId,


                DrugSaleDetailsHistoryModel = obj.DrugSaleDetailsHistory.Select(Create).ToList()
            };
        }

        public DrugSaleDetailsHistory Create(DrugSaleDetailsHistoryModel obj)
        {
            return new DrugSaleDetailsHistory
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugSaleHistoryId = obj.DrugSaleHistoryId,
                Quantity = obj.Quantity,
                SaleDiscount = obj.SaleDiscount,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total
            };
        }

        public DrugSaleDetailsModel Create(DrugSaleDetails obj)
        {
            return new DrugSaleDetailsModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugSaleId = obj.DrugSaleId,
                Quantity = obj.Quantity,
                SaleDiscount = obj.SaleDiscount,
                SubTotal = obj.SubTotal,
                UnitPrice = obj.UnitPrice,
                Total = obj.Total,
                DrugName = obj.Drug.D_TRADE_NAME,
                DrugType = obj.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                UnitStrength = obj.Drug.D_UNIT_STRENGTH
            };
        }
        public DrugSale Create(DrugSaleModel obj)
        {
            return new DrugSale
            {
                Id = obj.Id,
                LotId = obj.LotId,

                MemoNo = obj.MemoNo,
                SaleDateTime = obj.SaleDateTime,
                SalePrice = obj.SalePrice,
                SaleQty = obj.SaleQty,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TxnNo = obj.TxnNo,
                Amount = obj.Amount,
                Vat = obj.Vat,
                PatientId = obj.PatientId,
                PatientName = obj.PatientName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus,
                Remarks = obj.Remarks
            };
        }

        public DrugSaleModel Create(DrugSale obj)
        {
            return new DrugSaleModel
            {
                Id = obj.Id,
                LotId = obj.LotId,

                MemoNo = obj.MemoNo,
                SaleDateTime = obj.SaleDateTime,
                SalePrice = obj.SalePrice,
                SaleQty = obj.SaleQty,
                SaleDiscount = obj.SaleDiscount,
                SpecialDiscount = obj.SpecialDiscount,
                TxnNo = obj.TxnNo,
                Amount = obj.Amount,
                Vat = obj.Vat,
                PatientId = obj.PatientId,
                PatientName = obj.PatientName,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus,
                Remarks = obj.Remarks,
                DrugSaleDetailsModel = obj.DrugSaleDetails.Select(Create).ToList()
            };
        }
        public ShiftInfo Create(ShiftInfoModel obj)
        {
            return new ShiftInfo
            {
                Id = obj.Id,
                Title = obj.Title,
                Type = obj.Type,
                StartDay = obj.StartDay,
                DayOn = obj.DayOn,
                DayOff = obj.DayOff,
                StartTime = obj.StartTime,
                WorkingHour = obj.WorkingHour,
                EndTime = obj.EndTime,
                HasLunchDinner = obj.HasLunchDinner,
                BeginTime = obj.BeginTime,
                Duration = obj.Duration,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }

        public ShiftInfoModel Create(ShiftInfo obj)
        {
            return new ShiftInfoModel
            {
                Id = obj.Id,
                Title = obj.Title,
                Type = obj.Type,
                StartDay = obj.StartDay,
                DayOn = obj.DayOn,
                DayOff = obj.DayOff,
                StartTime = obj.StartTime,
                WorkingHour = obj.WorkingHour,
                EndTime = obj.EndTime,
                HasLunchDinner = obj.HasLunchDinner,
                BeginTime = obj.BeginTime,
                Duration = obj.Duration,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }
        public Holiday Create(HolidayModel obj)
        {
            return new Holiday
            {
                Id = obj.Id,
                Name = obj.Name,
                StartDaY = obj.StartDaY,
                EndDaY = obj.EndDaY,
                NoDay = obj.NoDay,
                Notes = obj.Notes,
                CreatedBy = obj.CreatedBy,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }


        public HolidayModel Create(Holiday obj)
        {
            return new HolidayModel
            {
                Id = obj.Id,
                Name = obj.Name,
                StartDaY = obj.StartDaY,
                EndDaY = obj.EndDaY,
                NoDay = obj.NoDay,
                Notes = obj.Notes,
                CreatedBy = obj.CreatedBy,
                RecStatus = obj.RecStatus,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
            };
        }


        public LoanConfig Create(LoanConfigModel obj)
        {
            return new LoanConfig
            {
                Id = obj.Id,
                Code = obj.Code,
                LoanTitle = obj.LoanTitle,
                Note = obj.Note,
                IsbasedOnSalary = obj.IsbasedOnSalary,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }

        public LoanConfigModel Create(LoanConfig obj)
        {
            return new LoanConfigModel
            {
                Id = obj.Id,
                Code = obj.Code,
                LoanTitle = obj.LoanTitle,
                Note = obj.Note,
                IsbasedOnSalary = obj.IsbasedOnSalary,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }

        public loanConfigPlan Create(LoanConfigPlanModel obj)
        {
            return new loanConfigPlan
            {
                Id = obj.Id,
                LoanConfigId = obj.LoanConfigId,
                StartAmount = obj.StratAmount,
                EndAmount = obj.EndAmount,
                IterestRate = obj.InterestRate,
                NnumberOfInstalment = obj.NumberofInstallment


            };
        }

        public LoanConfigPlanModel Create(loanConfigPlan obj)
        {
            return new LoanConfigPlanModel
            {
                Id = obj.Id,
                LoanConfigId = obj.LoanConfigId,
                StratAmount = obj.StartAmount,
                EndAmount = obj.EndAmount,
                InterestRate = obj.IterestRate,
                NumberofInstallment = obj.NnumberOfInstalment


            };
        }
        public TaxConfiguration Create(TaxConfigurationModel obj)
        {
            return new TaxConfiguration
            {
                Id = obj.Id,
                StartRange = obj.StartRange,
                EndRange = obj.EndRange,
                TaxPercentage = obj.TaxPercentage,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }



        public TaxConfigurationModel Create(TaxConfiguration obj)
        {
            return new TaxConfigurationModel
            {
                Id = obj.Id,
                StartRange = obj.StartRange,
                EndRange = obj.EndRange,
                TaxPercentage = obj.TaxPercentage,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }



        public StockIn Create(StockInModel obj)
        {
            return new StockIn
            {
                Id = obj.Id,
                TxnNo = obj.TxnNo,
                LotId = obj.LotId,
                InvNo = obj.InvNo,
                InvDate = obj.InvDate,
                InvQty = obj.InvQty,
                InvAmount = obj.InvAmount,
                DpoId = obj.DpoId,
                //StoreItemId = obj.StoreItemId,
                //PaymentStatus = obj.PaymentStatus,
                RecordDate = obj.RecordDate,
                Price = obj.Price,

            };
        }
        public StockInModel Create(StockIn obj)
        {
            return new StockInModel
            {
                Id = obj.Id,

                TxnNo = obj.TxnNo,
                LotId = obj.LotId,
                InvNo = obj.InvNo,
                InvDate = obj.InvDate,
                InvQty = obj.InvQty,
                InvAmount = obj.InvAmount,
                DpoId = obj.DpoId,
                //StoreItemId = obj.StoreItemId,
                //ItemName=obj.StoreItem.ItemName,
                //PaymentStatus = obj.PaymentStatus,
                RecordDate = obj.RecordDate,

                Price = obj.Price,
                StockInDetailsModels = obj.StockInDetails.Select(Create).ToList()


            };
        }
        public StockInDetails Create(StockInDetailsModel obj)
        {
            return new StockInDetails
            {
                Id = obj.Id,
                StockInId = obj.StockInId,
                StoreItemId = obj.StoreItemId,
                UnitPrice = obj.UnitPrice,
                CostPrice = obj.CostPrice,
                SubTotalPrice = obj.SubTotalPrice,
                AvailableQuantity = obj.AvailableQuantity,
                DisturbedQuantity = obj.DisturbedQuantity,
                ExpDate = obj.ExpDate,
                MafDate = obj.MafDate,
                SalePrice = obj.SalePrice,

                StockQuantity = obj.StockQuantity,
                RemainingQuantity = obj.RemainingQuantity,

            };
        }
        public StockInDetailsModel Create(StockInDetails obj)
        {
            return new StockInDetailsModel
            {
                Id = obj.Id,
                StoreItemId = obj.StoreItemId,
                StockInId = obj.StockInId,
                UnitPrice = obj.UnitPrice,
                StoreItemName = obj.StoreItems.ItemName,

                CostPrice = obj.CostPrice,
                SubTotalPrice = obj.SubTotalPrice,
                AvailableQuantity = obj.AvailableQuantity,
                DisturbedQuantity = obj.DisturbedQuantity,

                SalePrice = obj.SalePrice,
                ExpDate = obj.ExpDate,
                MafDate = obj.MafDate,
                StockQuantity = obj.StockQuantity,
                RemainingQuantity = obj.RemainingQuantity,


            };
        }



        public StockOutItem Create(StockOutItemModel obj)
        {
            return new StockOutItem
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                LotId = obj.LotId,
                TxnNo = obj.TxnNo,
                DepartmentId = obj.DepartmentId,
                Date = obj.Date,
                TotalQty = obj.TotalQty,
                StocOutQty = obj.StocOutQty,
                Amount = obj.Amount,
                IssuedFor = obj.IssuedFor,
                RecivedBy = obj.RecivedBy
            };
        }
        public StockOutItemModel Create(StockOutItem obj)
        {
            return new StockOutItemModel
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                LotId = obj.LotId,
                TxnNo = obj.TxnNo,
                TotalQty = obj.TotalQty,
                StocOutQty = obj.StocOutQty,
                Amount = obj.Amount,
                DepartmentId = obj.DepartmentId,
                DepartmentName = obj.Department.Name,
                Date = obj.Date,
                IssuedFor = obj.IssuedFor,
                RecivedBy = obj.RecivedBy,

                StockOutDetailsModel = obj.StockOutDetails.Select(Create).ToList()


            };
        }

        public StockOutDetails Create(StockOutDetailsModel obj)
        {
            return new StockOutDetails
            {
                Id = obj.Id,

                StoreItemId = obj.StoreItemId,
                StockOutItemId = obj.StockOutItemId,
                UnitPrice = obj.UnitPrice,
                Quantity = obj.Quantity,
                SubTotal = obj.SubTotal,
                Total = obj.Total


            };
        }
        public StockOutDetailsModel Create(StockOutDetails obj)
        {
            return new StockOutDetailsModel
            {
                Id = obj.Id,

                StoreItemId = obj.StoreItemId,
                StoreItemName = obj.StoreItem.ItemName,
                StockOutItemId = obj.StockOutItemId,
                UnitPrice = obj.UnitPrice,
                Quantity = obj.Quantity,
                SubTotal = obj.SubTotal,
                Total = obj.Total,
            };
        }


        public DrugStockIn Create(DrugStockInModel obj)
        {
            return new DrugStockIn
            {
                Id = obj.Id,
                TxnNo = obj.TxnNo,
                LotId = obj.LotId,
                InvNo = obj.InvNo,
                InvDate = obj.InvDate,
                InvQty = obj.InvQty,
                InvAmount = obj.InvAmount,
                DpoId = obj.DpoId,
                DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,

                PaymentStatus = obj.PaymentStatus,
                RecordDate = obj.RecordDate,
                SetUpUser = obj.SetUpUser,
                RecStatus = obj.RecStatus,
                SetUpDate = obj.SetUpDate,
                NetAmount = obj.NetAmount,
                VatAmount = obj.VatAmount,
                DiscountAmount = obj.DiscountAmount,

            };
        }
        public DrugStockInModel Create(DrugStockIn obj)
        {
            return new DrugStockInModel
            {
                Id = obj.Id,

                TxnNo = obj.TxnNo,
                LotId = obj.LotId,
                InvNo = obj.InvNo,
                InvDate = obj.InvDate,
                InvQty = obj.InvQty,
                InvAmount = obj.InvAmount,
                DpoId = obj.DpoId,
                DRUG_MANUFACTURERId = obj.DRUG_MANUFACTURERId,
                DRUG_MANUFACTURERName = obj.DRUG_MANUFACTURER.DM_NAME,
                PaymentStatus = obj.PaymentStatus,
                RecordDate = obj.RecordDate,
                SetUpUser = obj.SetUpUser,
                RecStatus = obj.RecStatus,
                SetUpDate = obj.SetUpDate,
                NetAmount = obj.NetAmount,
                VatAmount = obj.VatAmount,
                DiscountAmount = obj.DiscountAmount,
                DrugStockDetailsModels = obj.DrugStockDetails.Select(Create).ToList()

            };
        }



        public DrugStockDetails Create(DrugStockDetailsModel obj)
        {
            return new DrugStockDetails
            {
                Id = obj.Id,
                DRUGId = obj.DRUGId,
                DrugStockInId = obj.DrugStockInId,
                UnitPrice = obj.UnitPrice,
                CostPrice = obj.CostPrice,
                SubTotalPrice = obj.SubTotalPrice,
                AvailableQuantity = obj.AvailableQuantity,
                DisturbedQuantity = obj.DisturbedQuantity,
                DiscountPercent = obj.DiscountPercent,
                ExpDate = obj.ExpDate,
                SalePrice = obj.SalePrice,
                MafDate = obj.MafDate,
                StockQuantity = obj.StockQuantity,
                RemainingQuantity = obj.RemainingQuantity,

            };
        }
        public DrugStockDetailsModel Create(DrugStockDetails obj)
        {
            return new DrugStockDetailsModel
            {
                Id = obj.Id,
                DRUGId = obj.DRUGId,
                DrugStockInId = obj.DrugStockInId,
                UnitPrice = obj.UnitPrice,
                //DrugName = obj.DRUG.D_TRADE_NAME,
                //DrugType = obj.DRUG.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                //DrugUnitStrength = obj.DRUG.D_UNIT_STRENGTH,
                CostPrice = obj.CostPrice,
                SubTotalPrice = obj.SubTotalPrice,
                AvailableQuantity = obj.AvailableQuantity,
                DisturbedQuantity = obj.DisturbedQuantity,
                DiscountPercent = obj.DiscountPercent,
                ExpDate = obj.ExpDate,
                SalePrice = obj.SalePrice,
                MafDate = obj.MafDate,
                StockQuantity = obj.StockQuantity,
                RemainingQuantity = obj.RemainingQuantity,


            };
        }
        public StoreRequisition Create(StoreRequisitionModel obj)
        {
            return new StoreRequisition
            {
                Id = obj.Id,
                ApprovedBy = obj.ApprovedBy,
                DepartmentId = obj.DepartmentId,
                RequisitionBy = obj.RequisitionBy,
                RequisitionDate = obj.RequisitionDate,
                RequisitionNo = obj.RequisitionNo
            };
        }


        public StoreRequisitionModel Create(StoreRequisition obj)
        {
            return new StoreRequisitionModel
            {
                Id = obj.Id,
                ApprovedBy = obj.ApprovedBy,
                DepartmentId = obj.DepartmentId,
                DepartmentName = obj.Department.Name,
                RequisitionBy = obj.RequisitionBy,
                RequisitionDate = obj.RequisitionDate,
                RequisitionNo = obj.RequisitionNo,
                StoreRequisitionDetailsModels = obj.StoreRequisitionDetails.Select(Create).ToList()


            };
        }
        public StoreRequisitionDetailsModel Create(StoreRequisitionDetails obj)
        {
            return new StoreRequisitionDetailsModel
            {
                Id = obj.Id,
                StoreItemId = obj.StoreItemId,
                StoreItemName = obj.StoreItemName,

                StoreRequsitionId = obj.StoreRequsitionId,

                Quantity = obj.Quantity,


            };
        }


        public StoreRequisitionDetails Create(StoreRequisitionDetailsModel obj)
        {
            return new StoreRequisitionDetails
            {
                Id = obj.Id,
                StoreItemId = obj.StoreItemId,
                StoreItemName = obj.StoreItemName,

                StoreRequsitionId = obj.StoreRequsitionId,

                Quantity = obj.Quantity,
            };
        }

        public PharmacyRequisition Create(PharmacyRequisitionModel obj)
        {
            return new PharmacyRequisition
            {
                Id = obj.Id,
                ApprovedBy = obj.ApprovedBy,
                Department = obj.Department,
                RequisitionBy = obj.RequisitionBy,
                RequisitionDate = obj.RequisitionDate,
                RequisitionNo = obj.RequisitionNo
            };
        }


        public PharmacyRequisitionModel Create(PharmacyRequisition obj)
        {
            return new PharmacyRequisitionModel
            {
                Id = obj.Id,
                ApprovedBy = obj.ApprovedBy,
                Department = obj.Department,
                RequisitionBy = obj.RequisitionBy,
                RequisitionDate = obj.RequisitionDate,
                RequisitionNo = obj.RequisitionNo,
                PharmacyRequisitionDetailsModel = obj.PharmacyRequisitionDetails.Select(Create).ToList()


            };
        }

        public PharmacyRequisitionDetailsModel Create(PharmacyRequisitionDetails obj)
        {
            return new PharmacyRequisitionDetailsModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugName = obj.DrugName,
                GenericName = obj.GenericName,
                PharmacyrequsitionId = obj.PharmacyrequsitionId,
                PresenatationType = obj.PresenatationType,
                UnitStrength = obj.UnitStrength,
                Quantity = obj.Quantity,

            };
        }


        public PharmacyRequisitionDetails Create(PharmacyRequisitionDetailsModel obj)
        {
            return new PharmacyRequisitionDetails
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugName = obj.DrugName,
                GenericName = obj.GenericName,
                PharmacyrequsitionId = obj.PharmacyrequsitionId,
                Quantity = obj.Quantity,
                PresenatationType = obj.PresenatationType,
                UnitStrength = obj.UnitStrength
            };
        }
        public DrugDose Create(DrugDoseModel obj)
        {
            return new DrugDose
            {
                Id = obj.Id,
                DD_DPT_ID = obj.DD_DPT_ID,
                DD_D_ID = obj.DD_D_ID,
                Description = obj.Description,
                SetDateTime = obj.SetDateTime,
                SetUpUser = obj.SetUpUser,
                RecStatus = obj.RecStatus
            };
        }
        public DrugDoseModel Create(DrugDose obj)
        {
            return new DrugDoseModel
            {
                Id = obj.Id,
                DD_DPT_ID = obj.DD_DPT_ID,
                DD_D_ID = obj.DD_D_ID,
                Description = obj.Description,
                SetDateTime = obj.SetDateTime,
                SetUpUser = obj.SetUpUser,
                RecStatus = obj.RecStatus,
                DD_D_Name = obj.DRUG.D_TRADE_NAME
            };
        }
        public DrugGroup Create(DrugGroupModel obj)
        {
            return new DrugGroup
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status

            };
        }
        public DrugGroupModel Create(DrugGroup obj)
        {
            return new DrugGroupModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Status = obj.Status
            };
        }

        public DrugDailyStockHistory Create(DrugDailyStockHistoryModel obj)
        {
            return new DrugDailyStockHistory
            {
                Id = obj.Id,
                DrugStockInId = obj.DrugStockInId,
                DrugId = obj.DrugId,
                DisbusQty = obj.DisbusQty,
                RemQty = obj.RemQty,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus

            };
        }

        public DrugDailyStockHistoryModel Create(DrugDailyStockHistory obj)
        {
            return new DrugDailyStockHistoryModel
            {
                Id = obj.Id,
                DrugStockInId = obj.DrugStockInId,
                DrugId = obj.DrugId,
                DisbusQty = obj.DisbusQty,
                RemQty = obj.RemQty,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus

            };
        }

        public DrugDoseChartModel Create(DrugDoseChart obj)
        {
            return new DrugDoseChartModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,
                DrugName = obj.Drug.D_TRADE_NAME,
                MinAge = obj.MinAge,
                MaxAge = obj.MaxAge,
                Advice = obj.Advice,
                Dose = obj.Dose,
                Duration = obj.Duration,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus

            };
        }

        public DrugDoseChart Create(DrugDoseChartModel obj)
        {
            return new DrugDoseChart
            {
                Id = obj.Id,
                DrugId = obj.DrugId,

                MinAge = obj.MinAge,
                MaxAge = obj.MaxAge,
                Advice = obj.Advice,
                Dose = obj.Dose,
                Duration = obj.Duration,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus

            };
        }

        public DrugDuration Create(DrugDurationModel obj)
        {
            return new DrugDuration
            {
                Id = obj.Id,
                Description = obj.Description,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus
            };
        }
        public DrugDurationModel Create(DrugDuration obj)
        {
            return new DrugDurationModel
            {
                Id = obj.Id,
                Description = obj.Description,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus
            };
        }

        public DrugInvoicePayment Create(DrugInvoicePaymentModel obj)
        {
            return new DrugInvoicePayment
            {
                Id = obj.Id,
                LotId = obj.LotId,
                TxnId = obj.TxnId,
                TxmDate = obj.TxnDate,
                PaymentAmount = obj.PaymentAmount,
                RemAmount = obj.RemAmount,
                PayType = obj.PayType,
                ChequeNo = obj.ChequeNo,
                ChequeDate = obj.ChequeDate,
                BankAccount = obj.BankAccount,
                ReceiveBy = obj.ReceiveBy,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus

            };
        }

        public DrugInvoicePaymentModel Create(DrugInvoicePayment obj)
        {
            return new DrugInvoicePaymentModel
            {
                Id = obj.Id,
                LotId = obj.LotId,
                TxnId = obj.TxnId,
                TxnDate = obj.TxmDate,
                PaymentAmount = obj.PaymentAmount,
                RemAmount = obj.RemAmount,
                PayType = obj.PayType,
                ChequeNo = obj.ChequeNo,
                ChequeDate = obj.ChequeDate,
                BankAccount = obj.BankAccount,
                ReceiveBy = obj.ReceiveBy,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

                RecStatus = obj.RecStatus

            };
        }

        public DrugSaleReturn Create(DrugSaleReturnModel obj)
        {
            return new DrugSaleReturn
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                LotNo = obj.LotNo,
                DrugId = obj.DrugId,
                ReturnPrice = obj.ReturnPrice,
                ReturnQty = obj.ReturnQty,
                ReturnSubTotal = obj.ReturnSubTotal,
                ReturnDiscount = obj.ReturnDiscount,
                ReturnDate = obj.ReturnDate,
                TxnNo = obj.TxnNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

            };
        }

        public DrugSaleReturnModel Create(DrugSaleReturn obj)
        {
            return new DrugSaleReturnModel
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                LotNo = obj.LotNo,
                DrugId = obj.DrugId,
                DrugName = obj.Drug.D_TRADE_NAME + " " + obj.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION + " " + (obj.Drug.D_UNIT_STRENGTH),
                ReturnPrice = obj.ReturnPrice,
                ReturnQty = obj.ReturnQty,
                ReturnSubTotal = obj.ReturnSubTotal,
                ReturnDiscount = obj.ReturnDiscount,
                ReturnDate = obj.ReturnDate,
                TxnNo = obj.TxnNo,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,

            };
        }

        public DrugsSelectedGroups Create(DrugsSelectedGroupsModel obj)
        {
            return new DrugsSelectedGroups
            {
                Id = obj.Id,
                DrugId = obj.DrugId,

                DrugGroupId = obj.DrugGroupId,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
            };
        }

        public DrugsSelectedGroupsModel Create(DrugsSelectedGroups obj)
        {
            return new DrugsSelectedGroupsModel
            {
                Id = obj.Id,
                DrugId = obj.DrugId,

                DrugGroupId = obj.DrugGroupId,
                DrugGroupName = obj.DrugsGroup.Name,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
            };
        }
        public OccurrenceType Create(OccurrenceTypeModel obj)
        {
            return new OccurrenceType
            {
                Id = obj.Id,
                Name = obj.Name,
                Note = obj.Note,
                Status = obj.Status,
                Abbreviation = obj.Abbreviation,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }
        public OccurrenceTypeModel Create(OccurrenceType obj)
        {
            return new OccurrenceTypeModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Note = obj.Note,
                Status = obj.Status,
                Abbreviation = obj.Abbreviation,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }

        public Occurrence Create(OccurrenceModel obj)
        {
            return new Occurrence
            {
                Id = obj.Id,
                EiCode = obj.EiCode,
                OccurrenceTypeId = obj.OccurrenceTypeId,
                Date = obj.Date,
                ExpireDate = obj.ExpireDate,
                Note = obj.Note,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }


        public OccurrenceModel Create(Occurrence obj)
        {
            return new OccurrenceModel
            {
                Id = obj.Id,
                EiCode = obj.EiCode,
                OccurrenceTypeId = obj.OccurrenceTypeId,
                OccurrenceTypeName = obj.OccurrenceTypes.Name,
                Date = obj.Date,
                ExpireDate = obj.ExpireDate,
                Note = obj.Note,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }



        public OperationNote Create(OperationNoteModel obj)
        {
            return new OperationNote
            {
                Id = obj.Id,
                PrescriptionId = obj.PrescriptionId,
                DoctorId = obj.DoctorId,
                PlaceOfOperation = obj.PlaceOfOperation,
                DateOfOperation = obj.DateOfOperation,
                PreOpDiagnosis = obj.PreOpDiagnosis,
                PerOpDiagnosis = obj.PerOpDiagnosis,
                NameOfOperation = obj.NameOfOperation,
                Anaesthesia = obj.Anaesthesia,
                Anesthesiologist = obj.Anesthesiologist,
                TimeOfSurgery = obj.TimeOfSurgery,
                TimeOfAnesthesia = obj.TimeOfAnesthesia,
                Surgeon = obj.Surgeon,
                Asistant = obj.Asistant,
                PositionOfPatient = obj.PositionOfPatient,
                Description = obj.Description
            };

        }


        public OperationNoteModel Create(OperationNote obj)
        {
            return new OperationNoteModel
            {
                Id = obj.Id,
                PrescriptionId = obj.PrescriptionId,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                PlaceOfOperation = obj.PlaceOfOperation,
                DateOfOperation = obj.DateOfOperation,
                PreOpDiagnosis = obj.PreOpDiagnosis,
                PerOpDiagnosis = obj.PerOpDiagnosis,
                NameOfOperation = obj.NameOfOperation,
                Anaesthesia = obj.Anaesthesia,
                Anesthesiologist = obj.Anesthesiologist,
                TimeOfSurgery = obj.TimeOfSurgery,
                TimeOfAnesthesia = obj.TimeOfAnesthesia,
                Surgeon = obj.Surgeon,
                Asistant = obj.Asistant,
                PositionOfPatient = obj.PositionOfPatient,
                Description = obj.Description
            };

        }

        public ChiefComplaintModel Create(ChiefComplaint obj)
        {
            return new ChiefComplaintModel
            {
                Id = obj.Id,
                Title = obj.Title
            };
        }

        public ChiefComplaint Create(ChiefComplaintModel obj)
        {
            return new ChiefComplaint
            {
                Id = obj.Id,
                Title = obj.Title
            };
        }


        public ChiefComplaintDurationModel Create(ChiefComplaintDuration obj)
        {
            return new ChiefComplaintDurationModel
            {
                Id = obj.Id,
                Details = obj.Details
            };
        }

        public ChiefComplaintDuration Create(ChiefComplaintDurationModel obj)
        {
            return new ChiefComplaintDuration
            {
                Id = obj.Id,
                Details = obj.Details
            };
        }

        public PatientAllergyInformationModel Create(PatientAllergyInformation obj)
        {
            return new PatientAllergyInformationModel
            {
                Id = obj.Id,
                AllergyInformationId = obj.AllergyInformationId,
                AllergyName = obj.AllergyInformation.Title,
                AllergySubstanceId = obj.AllergySubstanceId,
                AllergySubstanceName = obj.AllergySubstance.Details,
                PatientHistoryId = obj.PatientHistoryId
            };
        }

        public PatientAllergyInformation Create(PatientAllergyInformationModel obj)
        {
            return new PatientAllergyInformation
            {
                Id = obj.Id,
                AllergyInformationId = obj.AllergyInformationId,
                AllergySubstanceId = obj.AllergySubstanceId,
                CreatedDate = DateTime.Now,
                PatientHistoryId = obj.PatientHistoryId
            };
        }


        public PatientEnrollModel Create(PatientEnroll obj)
        {
            return new PatientEnrollModel
            {
                Id = obj.Id,
                SerialNo = obj.SerialNo,
                PatientInformationId = obj.PatientId,
                PatientInformationName = obj.PatientInformation.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                Date = obj.Date,
                Time = obj.Time,
                Type = obj.Type,
                Status = obj.Status,
            };
        }

        public PatientEnroll Create(PatientEnrollModel obj)
        {
            return new PatientEnroll
            {
                Id = obj.Id,
                SerialNo = obj.SerialNo,
                PatientId = obj.PatientInformationId,

                DoctorId = obj.DoctorId,

                Date = obj.Date,
                Time = obj.Time,
                Type = obj.Type,
                Status = obj.Status,
            };
        }

        public PatientFamilyDiseaseModel Create(PatientFamilyDisease obj)
        {
            return new PatientFamilyDiseaseModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                DiseaseId = obj.DiseaseId,
                DiseaseName = obj.Disease.MD_NAME,
                FamilyTreeId = obj.FamilyTreeId,
                FamilyTreeTitle = obj.FamilyTree.Title
            };
        }

        public PatientFamilyDisease Create(PatientFamilyDiseaseModel obj)
        {
            return new PatientFamilyDisease
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                DiseaseId = obj.DiseaseId,
                CreatedDate = DateTime.Now,
                FamilyTreeId = obj.FamilyTreeId
            };
        }


        public PatientChiefComplaintModel Create(PatientChiefComplaint obj)
        {
            return new PatientChiefComplaintModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                ChifComplaintDurationId = obj.ChiefComplaintDetailsId,
                ChifComplaintDuration = obj.ChiefComplaintDuration.Details,
                ChiefComplaintId = obj.ChiefComplaintId,
                ChiefComplaint = obj.ChiefComplaint.Title
            };
        }

        public PatientChiefComplaint Create(PatientChiefComplaintModel obj)
        {
            return new PatientChiefComplaint
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                ChiefComplaintDetailsId = obj.ChifComplaintDurationId,
                CreatedDate = DateTime.Now,
                ChiefComplaintId = obj.ChiefComplaintId
            };
        }


        public PatientGeneralExamModel Create(PatientGeneralExam obj)
        {
            return new PatientGeneralExamModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                BloodPressure = obj.BloodPressure,
                Height = obj.Height,
                PulseRythm = obj.PulseRythm,
                PulseType = obj.PulseType,
                PulseRatePerMinutes = obj.PulseRatePerMinutes,
                Temperature = obj.Temperature,
                Weight = obj.Weight
            };
        }

        public PatientGeneralExam Create(PatientGeneralExamModel obj)
        {
            return new PatientGeneralExam
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                BloodPressure = obj.BloodPressure,
                Height = obj.Height,
                PulseRythm = obj.PulseRythm,
                PulseType = obj.PulseType,
                PulseRatePerMinutes = obj.PulseRatePerMinutes,
                Temperature = obj.Temperature,
                Weight = obj.Weight
            };
        }

        public PatientHistoryModel Create(PatientHistory obj)
        {

            List<PatientAllergyInformationModel> objPatientAllergyInformationModels = new List<PatientAllergyInformationModel>();
            List<PatientChiefComplaintModel> objPatientChiefComplaintModel = new List<PatientChiefComplaintModel>();
            List<PatientGeneralExamModel> objPatientGeneralExamModels = new List<PatientGeneralExamModel>();
            List<PatientPastHistoryOfMadicationModel> objPatientPastHistoryOfMadicationModels = new List<PatientPastHistoryOfMadicationModel>();
            List<PatientPastIllnessModel> objPatientPastIllnessModels = new List<PatientPastIllnessModel>();
            List<PatientPersonalHistoryModel> objPatientPersonalHistoryModels = new List<PatientPersonalHistoryModel>();
            List<PatientPrescriptionModel> objPatientPrescriptionModels = new List<PatientPrescriptionModel>();
            List<PatientFamilyDiseaseModel> objPatientFamilyDiseaseModels = new List<PatientFamilyDiseaseModel>();

            obj.PatientAllergyInformations.ForEach(fe => objPatientAllergyInformationModels.Add(Create(fe)));
            obj.PatientChiefComplaints.ForEach(fe => objPatientChiefComplaintModel.Add(Create(fe)));
            obj.PatientGeneralExams.ForEach(fe => objPatientGeneralExamModels.Add(Create(fe)));
            obj.PatientPastHistoryOfMadications.ForEach(fe => objPatientPastHistoryOfMadicationModels.Add(Create(fe)));
            obj.PatientPastIllness.ForEach(fe => objPatientPastIllnessModels.Add(Create(fe)));

            obj.PatientPersonalHistories.ForEach(fe => objPatientPersonalHistoryModels.Add(Create(fe)));


            obj.PatientPrescriptions.ForEach(fe => objPatientPrescriptionModels.Add(Create(fe)));
            obj.PatientFamilyDiseases.ForEach(fe => objPatientFamilyDiseaseModels.Add(Create(fe)));

            return new PatientHistoryModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                PatientName = obj.PatientInformation.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                HistoryTakenDate = obj.HistoryTakenDate,
                HistoryTakenTime = obj.HistoryTakenTime,


                PatientAllergyInformation = objPatientAllergyInformationModels,
                PatientChiefComplaint = objPatientChiefComplaintModel,
                PatientGeneralExam = objPatientGeneralExamModels,
                PatientPastHistoryOfMadication = objPatientPastHistoryOfMadicationModels,
                PatientPastIllness = objPatientPastIllnessModels,
                PatientPersonalHistory = objPatientPersonalHistoryModels,
                PatientPrescription = objPatientPrescriptionModels,
                PatientFamilyDisease = objPatientFamilyDiseaseModels
            };
        }

        public PatientHistory Create(PatientHistoryModel obj)
        {
            return new PatientHistory
            {
                Id = obj.Id,
                PatientId = obj.PatientId,

                DoctorId = obj.DoctorId,

                HistoryTakenDate = obj.HistoryTakenDate,
                HistoryTakenTime = obj.HistoryTakenTime


            };
        }
        public PatientInformation Create(PatientInformationModel obj)
        {
            return new PatientInformation
            {
                Id = obj.Id,
                Name = obj.Name,
                PatientCode = obj.PatientCode,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                Address = obj.Address,
                ReferanceName = obj.ReferanceName,
                DateOfBirth = obj.DateOfBirth,
                BloodGroup = obj.BloodGroup,
                OccupationId = obj.OccupationId,
                PatientEducationId = obj.PatientEducationId,
                MobileNumber = obj.MobileNumber,
                Picture = obj.Picture,

                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                Remarks = obj.Remarks,
                //ModifiedBy = obj.ModifiedBy,
                //ModifiedDate = obj.ModifiedDate
            };
        }

        public PatientInformationModel Create(PatientInformation obj)
        {
            return new PatientInformationModel
            {
                Id = obj.Id,
                Name = obj.Name,
                PatientCode = obj.PatientCode,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                Address = obj.Address,
                ReferanceName = obj.ReferanceName,
                DateOfBirth = obj.DateOfBirth,
                BloodGroup = obj.BloodGroup,
                OccupationId = obj.OccupationId,
                PatientEducationId = obj.PatientEducationId,
                MobileNumber = obj.MobileNumber,
                Picture = obj.Picture,
                Sex = obj.Sex,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                Remarks = obj.Remarks,
                //ModifiedBy = obj.ModifiedBy,
                //ModifiedDate = obj.ModifiedDate,
                //PatientDetailsModel = obj.PatientDetails.Select(Create).ToList()


            };
        }
        public Patient Create(PatientModel obj)
        {
            return new Patient
            {
                Id = obj.Id,
                Name = obj.Name,
                PatientCode = obj.PatientCode,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                Address = obj.Address,
                ReferanceName = obj.ReferanceName,
                //DateOfBirth = obj.DateOfBirth,
                Age = obj.Age,
                BloodGroup = obj.BloodGroup,
                OccupationId = obj.OccupationId,
                EducationId = obj.EducationId,
                MobileNumber = obj.MobileNumber,
                Picture = obj.Picture,
                MarketingBy = obj.MarketingBy,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Discount = obj.Discount,
                TotalAmount = obj.TotalAmount,
                ChangeAmount = obj.ChangeAmount,
                GivenAmount = obj.GivenAmount,
                TransactionNumber = obj.TransactionNumber,
                TransactionType = obj.TransactionType,
                Sex = obj.Sex,
                Status = obj.Status,
                DeuAmount = obj.DeuAmount,
                VoucherNo = obj.VoucherNo,
                ItemQuantity = obj.ItemQuantity,
                Remark = obj.Remark
            };
        }

        public PatientModel Create(Patient obj)
        {
            return new PatientModel
            {
                Id = obj.Id,
                Name = obj.Name,
                PatientCode = obj.PatientCode,
                FatherName = obj.FatherName,
                MotherName = obj.MotherName,
                Address = obj.Address,
                ReferanceName = obj.ReferanceName,
                //DateOfBirth = obj.DateOfBirth,
                Age = obj.Age,
                BloodGroup = obj.BloodGroup,
                OccupationId = obj.OccupationId,
                EducationId = obj.EducationId,
                MobileNumber = obj.MobileNumber,
                Picture = obj.Picture,
                MarketingBy = obj.MarketingBy,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                Discount = obj.Discount,
                TotalAmount = obj.TotalAmount,
                ChangeAmount = obj.ChangeAmount,
                GivenAmount = obj.GivenAmount,
                TransactionNumber = obj.TransactionNumber,
                TransactionType = obj.TransactionType,
                Sex = obj.Sex,
                Status = obj.Status,
                DeuAmount = obj.DeuAmount,
                VoucherNo = obj.VoucherNo,
                ItemQuantity = obj.ItemQuantity,
                Remark = obj.Remark,
                PatientDetailsModels = obj.PatientDetails.Select(Create).ToList()


            };
        }



        public PatientEducation Create(PatientEducationModel obj)
        {
            return new PatientEducation
            {
                Id = obj.Id,
                DegreeName = obj.DegreeName
            };
        }

        public PatientEducationModel Create(PatientEducation obj)
        {
            return new PatientEducationModel
            {
                Id = obj.Id,
                DegreeName = obj.DegreeName
            };
        }
        public PatientInvestigationModel Create(PatientInvestigation obj)
        {
            return new PatientInvestigationModel
            {
                Id = obj.Id,
                PatientPrescriptionId = obj.PatientPrescriptionId,
                TestCategoryId = obj.Test.TEST_CATEGORY.TC_ID,
                Findings = obj.Findings,
                TestCategoryName = obj.Test.TEST_CATEGORY.TC_TITLE,

                TestId = obj.TestId,
                TestName = obj.Test.T_NAME
            };
        }

        public PatientInvestigation Create(PatientInvestigationModel obj)
        {
            return new PatientInvestigation
            {
                Id = obj.Id,
                PatientPrescriptionId = obj.PatientPrescriptionId,
                TestId = obj.TestId,
                Findings = obj.Findings
            };
        }


        public PatientOldInvestigationModel Create(PatientOldInvestigation obj)
        {
            return new PatientOldInvestigationModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                TestCategoryId = obj.Test.TEST_CATEGORY.TC_ID,
                Findings = obj.Findings,
                TestCategoryName = obj.Test.TEST_CATEGORY.TC_TITLE,
                TestId = obj.TestId,
                TestName = obj.Test.T_NAME
            };
        }

        public PatientOldInvestigation Create(PatientOldInvestigationModel obj)
        {
            return new PatientOldInvestigation
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                TestId = obj.TestId,
                Findings = obj.Findings
            };
        }

        public PatientPastHistoryOfMadicationModel Create(PatientPastHistoryOfMadication obj)
        {
            return new PatientPastHistoryOfMadicationModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                DrugPresentaionTypeName = obj.DurgPresentationType.DPT_DESCRIPTION,
                DrugId = obj.DrugId,
                DrugName = obj.Drug.D_TRADE_NAME,
                DurgPresentationTypeId = obj.DurgPresentationTypeId
            };
        }

        public PatientPastHistoryOfMadication Create(PatientPastHistoryOfMadicationModel obj)
        {
            return new PatientPastHistoryOfMadication
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,

                DrugId = obj.DrugId,
                CreatedDate = DateTime.Now,
                DurgPresentationTypeId = obj.DurgPresentationTypeId
            };
        }

        public PatientPastIllnessModel Create(PatientPastIllness obj)
        {
            return new PatientPastIllnessModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                DiseaseId = obj.DiseaseId,
                Disease = obj.Disease.MD_NAME,
                DiseaseConditionId = obj.DiseaseConditionId,
                DiseaseCondition = obj.DiseaseCondition.Description
            };
        }

        public PatientPastIllness Create(PatientPastIllnessModel obj)
        {
            return new PatientPastIllness
            {
                PatientHistoryId = obj.PatientHistoryId,
                DiseaseId = obj.DiseaseId,
                CreatedDate = DateTime.Now,
                DiseaseConditionId = obj.DiseaseConditionId,

            };
        }

        public PatientPersonalAttributeModel Create(PatientPersonalAttribute obj)
        {
            return new PatientPersonalAttributeModel
            {
                Id = obj.Id,
                Title = obj.Title

            };
        }

        public PatientPersonalAttribute Create(PatientPersonalAttributeModel obj)
        {
            return new PatientPersonalAttribute
            {
                Id = obj.Id,
                Title = obj.Title
            };
        }


        public PatientPersonalHistoryModel Create(PatientPersonalHistory obj)
        {

            List<PatientPersonalHistoryDetailsModel> objPatientPersonalHistoryDetailsModel = new List<PatientPersonalHistoryDetailsModel>();
            obj.PatientPersonalHistoryDetails.ForEach(fe => objPatientPersonalHistoryDetailsModel.Add(Create(fe)));
            return new PatientPersonalHistoryModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                MaritalStatus = obj.MaritalStatus,
                SocialEconomicStatusId = obj.SocialEconomicStatusId,
                SocialEconomicStatusDetail = obj.SocialEconomicStatus.Details,
                PatientPersonalHistoryDetails = objPatientPersonalHistoryDetailsModel
            };
        }

        public PatientPersonalHistory Create(PatientPersonalHistoryModel obj)
        {

            return new PatientPersonalHistory
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                MaritalStatus = obj.MaritalStatus,
                SocialEconomicStatusId = obj.SocialEconomicStatusId,

            };
        }

        public PatientPersonalHistoryDetailsModel Create(PatientPersonalHistoryDetails obj)
        {
            return new PatientPersonalHistoryDetailsModel
            {
                Id = obj.Id,
                PatientPersonalHistoryId = obj.PatientPersonalHistoryId,
                PatientPersonalAttributeId = obj.PatientPersonalAttributeId,
                PatientPersonalAttributeTitle = obj.PatientPersonalAttribute.Title
            };
        }

        public PatientPersonalHistoryDetails Create(PatientPersonalHistoryDetailsModel obj)
        {
            return new PatientPersonalHistoryDetails
            {
                Id = obj.Id,
                PatientPersonalHistoryId = obj.PatientPersonalHistoryId,
                CreatedDate = DateTime.Now,
                PatientPersonalAttributeId = obj.PatientPersonalAttributeId
            };
        }

        public PatientPrescriptionModel Create(PatientPrescription obj)
        {

            List<PatientInvestigationModel> objPatientInvestigationModel = new List<PatientInvestigationModel>();
            List<PatientSpecialNoteModel> objPatientSpecialNoteModel = new List<PatientSpecialNoteModel>();
            List<PatientTreatmentModel> objPatientTreatmentModel = new List<PatientTreatmentModel>();

            obj.PatientInvestigations.ForEach(fe => objPatientInvestigationModel.Add(Create(fe)));
            obj.PatientSpecialNotes.ForEach(fe => objPatientSpecialNoteModel.Add(Create(fe)));
            obj.PatientTreatments.ForEach(fe => objPatientTreatmentModel.Add(Create(fe)));

            return new PatientPrescriptionModel
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                PatientId = obj.PatientId,
                PatientName = obj.PatientInformation.Name,
                DoctorId = obj.DoctorId,
                DoctorName = obj.DoctorInformation.Name,
                OrthopedicFindings = obj.OrthopedicFindings,
                Diagonosis = obj.Diagonosis,
                NextReviewDate = obj.NextReviewDate,
                Date = obj.Date,
                Time = obj.Time,
                BriefSummary = obj.BriefSummary,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                PatientInvestigation = objPatientInvestigationModel,
                PatientSpecialNote = objPatientSpecialNoteModel,
                PatientTreatment = objPatientTreatmentModel

            };
        }

        public PatientPrescription Create(PatientPrescriptionModel obj)
        {

            List<PatientInvestigation> objPatientInvestigationModel = new List<PatientInvestigation>();
            List<PatientSpecialNote> objPatientSpecialNoteModel = new List<PatientSpecialNote>();
            List<PatientTreatment> objPatientTreatmentModel = new List<PatientTreatment>();

            obj.PatientInvestigation.ForEach(fe => objPatientInvestigationModel.Add(Create(fe)));
            obj.PatientSpecialNote.ForEach(fe => objPatientSpecialNoteModel.Add(Create(fe)));
            obj.PatientTreatment.ForEach(fe => objPatientTreatmentModel.Add(Create(fe)));
            return new PatientPrescription
            {
                Id = obj.Id,
                PatientHistoryId = obj.PatientHistoryId,
                PatientId = obj.PatientId,

                DoctorId = obj.DoctorId,
                OrthopedicFindings = obj.OrthopedicFindings,
                Diagonosis = obj.Diagonosis,
                NextReviewDate = obj.NextReviewDate,
                Date = obj.Date,
                Time = obj.Time,
                BriefSummary = obj.BriefSummary,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate
            };
        }


        public PatientSpecialNoteModel Create(PatientSpecialNote obj)
        {
            return new PatientSpecialNoteModel
            {
                Id = obj.Id,
                PatientPrescriptionId = obj.PatientPrescriptionId,
                SpecialNoteId = obj.SpecialNoteId,
                SpecialNote = obj.SpecialNote.Note
            };
        }

        public PatientSpecialNote Create(PatientSpecialNoteModel obj)
        {
            return new PatientSpecialNote
            {
                Id = obj.Id,
                PatientPrescriptionId = obj.PatientPrescriptionId,
                SpecialNoteId = obj.SpecialNoteId

            };
        }

        public PatientTreatmentModel Create(PatientTreatment obj)
        {
            return new PatientTreatmentModel
            {
                Id = obj.Id,
                DrugDoseId = obj.DrugDoseId,
                DrugDoseDescription = obj.DrugDose.Description,
                PatientPrescriptionId = obj.PatientPrescriptionId,

                PresentationTypeId = obj.Drug.D_DPT_ID,
                PresentationTypeName = obj.Drug.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                DrugId = obj.DrugId,
                DrugName = obj.Drug.D_TRADE_NAME,

                DrugDurationId = obj.DrugDurationId,
                DrugDurationDescription = obj.DrugDuration.Description,
                DoctorNoteId = obj.DoctorNoteId,
                DoctorNote = obj.DoctorNote.Note,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate

            };
        }

        public PatientTreatment Create(PatientTreatmentModel obj)
        {
            return new PatientTreatment
            {
                Id = obj.Id,
                DrugDoseId = obj.DrugDoseId,

                PatientPrescriptionId = obj.PatientPrescriptionId,

                DrugId = obj.DrugId,


                DrugDurationId = obj.DrugDurationId,

                DoctorNoteId = obj.DoctorNoteId,

                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = DateTime.Now

            };
        }

        public ReportScanCopy Create(ReportScanCopyModel obj)
        {
            return new ReportScanCopy
            {
                Id = obj.Id,
                PrescriptionId = obj.PrescriptionId,
                Title = obj.Title,
                Description = obj.Description,
                DeliveryDate = obj.DeliveryDate,
                Url = obj.Url,
                ThumbnailUrl = obj.ThumbnailUrl
            };
        }


        public ReportScanCopyModel Create(ReportScanCopy obj)
        {
            return new ReportScanCopyModel
            {
                Id = obj.Id,
                PrescriptionId = obj.PrescriptionId,
                Title = obj.Title,
                Description = obj.Description,
                DeliveryDate = obj.DeliveryDate,
                Url = obj.Url,
                ThumbnailUrl = obj.ThumbnailUrl
            };
        }
        public PatientDetails Create(PatientDetailsModel obj)
        {
            return new PatientDetails
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                TestNameId = obj.TestNameId,
                Price = obj.Price,
                Discount = obj.Discount,
                Total = obj.Total,
                Quantity = obj.Quantity,
            };
        }

        public PatientDetailsModel Create(PatientDetails obj)
        {
            return new PatientDetailsModel
            {
                Id = obj.Id,
                PatientId = obj.PatientId,
                TestNameId = obj.TestNameId,
                Price = obj.Price,
                Discount = obj.Discount,
                Total = obj.Total,
                PatientName = obj.Patient.Name,
                TestName = obj.TestName.T_NAME,
                Quantity = obj.Quantity,
            };
        }



        public LeaveOfAbsenceMaster Create(LeaveOfAbsenceMasterModel obj)
        {
            return new LeaveOfAbsenceMaster
            {
                Id = obj.Id,
                EmployeeInfoId = obj.EmployeeInfoId,
                LeaveReason = obj.LeaveReason,
                Note = obj.Note,
                CoveringUserId = obj.CoveringUserId,
                VarifyUserId = obj.VarifyUserId,
                RequestedDate = obj.RequestedDate,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate
                //SetupDate = obj.SetupDate,
                //SetupUser = obj.SetupUser

            };
        }
        public LeaveOfAbsenceMasterModel Create(LeaveOfAbsenceMaster obj)
        {
            return new LeaveOfAbsenceMasterModel
            {
                Id = obj.Id,
                EmployeeInfoId = obj.EmployeeInfoId,
                //EmployeeInfoFirstName = obj.EmployeeInfo.FirstName,
                LeaveReason = obj.LeaveReason,
                Note = obj.Note,
                CoveringUserId = obj.CoveringUserId,
                VarifyUserId = obj.VarifyUserId,
                RequestedDate = obj.RequestedDate,
                Status = obj.Status,
                RecStatus = obj.RecStatus,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate

                //SetupDate = obj.SetupDate,
                //SetupUser = obj.SetupUser

            };
        }


        public LeaveOfAbsenceDetails Create(LeaveOfAbsenceDetailsModel obj)
        {
            return new LeaveOfAbsenceDetails
            {
                Id = obj.Id,
                LeaveTypeId = obj.LeaveTypeId,
                FromDate = obj.FromDate,
                ToDate = obj.ToDate,
                LeaveOfAbsenceMasterId = obj.LeaveOfAbsenceMasterId,
                LeaveYear = obj.LeaveYear,
                TotalHours = obj.TotalHours

            };
        }
        public LeaveOfAbsenceDetailsModel Create(LeaveOfAbsenceDetails obj)
        {
            return new LeaveOfAbsenceDetailsModel
            {
                Id = obj.Id,
                LeaveTypeId = obj.LeaveTypeId,
                LeaveTypeName = obj.LeaveType.TypeName,

                FromDate = obj.FromDate,
                ToDate = obj.ToDate,
                LeaveOfAbsenceMasterId = obj.LeaveOfAbsenceMasterId,
                LeaveYear = obj.LeaveYear,
                TotalHours = obj.TotalHours


            };
        }

        public LeaveType Create(LeaveTypeModel obj)
        {
            return new LeaveType
            {
                Id = obj.Id,
                TypeName = obj.TypeName,
                Abbreviation = obj.Abbreviation,
                Bank = obj.Bank,
                Color = obj.Color,
                HolidayConcurrent = obj.HolidayConcurrent,
                IsAdvance = obj.IsAdvance,
                IsPaid = obj.IsPaid,
                RecStatus = obj.RecStatus,
                SetupDate = obj.SetupDate,
                SetupUser = obj.SetupUser
            };
        }
        public LeaveTypeModel Create(LeaveType obj)
        {
            return new LeaveTypeModel
            {
                Id = obj.Id,
                TypeName = obj.TypeName,
                Abbreviation = obj.Abbreviation,
                Bank = obj.Bank,
                Color = obj.Color,
                HolidayConcurrent = obj.HolidayConcurrent,
                IsAdvance = obj.IsAdvance,
                IsPaid = obj.IsPaid,
                RecStatus = obj.RecStatus,
                SetupDate = obj.SetupDate,
                SetupUser = obj.SetupUser
            };
        }
        public LeavePlan Create(LeavePlanModel obj)
        {
            return new LeavePlan
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                IsYearSeniority = obj.IsYearSeniority,
                RecStatus = obj.RecStatus,
                SetupDate = obj.SetupDate,
                SetupUser = obj.SetupUser
            };
        }
        public LeavePlanModel Create(LeavePlan obj)
        {
            return new LeavePlanModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                IsYearSeniority = obj.IsYearSeniority,
                RecStatus = obj.RecStatus,
                SetupDate = obj.SetupDate,
                SetupUser = obj.SetupUser
            };
        }


        public LeavePlanRate Create(LeavePlanRateModel obj)
        {
            return new LeavePlanRate
            {
                Id = obj.Id,
                LeavePlanId = obj.LeavePlanId,
                LeaveTypeId = obj.LeaveTypeId,
                StartMonth = obj.StartMonth,
                EndMonth = obj.EndMonth,
                TimeDays = obj.TimeDays

            };
        }

        public LeavePlanRateModel Create(LeavePlanRate obj)
        {
            return new LeavePlanRateModel
            {
                Id = obj.Id,
                LeavePlanId = obj.LeavePlanId,
                LeavePlanName = obj.LeavePlan.Name,
                LeaveTypeId = obj.LeaveTypeId,
                TypeName = obj.LeaveType.TypeName,
                StartMonth = obj.StartMonth,
                EndMonth = obj.EndMonth,
                TimeDays = obj.TimeDays

            };
        }

        public EmployeeDesignation Create(EmployeeDesignationModel obj)
        {
            return new EmployeeDesignation
            {
                ED_ID = obj.ED_ID,
                ED_DESIGNATION = obj.ED_DESIGNATION,
                ED_FLSA_CODE = obj.ED_FLSA_CODE,
                ED_GL_ID = obj.ED_GL_ID,
                ED_HOUR_PER_WEEK = obj.ED_HOUR_PER_WEEK,
                ED_NO_POSITION = obj.ED_NO_POSITION,
                ED_SHORT_FORM = obj.ED_SHORT_FORM
            };
        }
        public EmployeeDesignationModel Create(EmployeeDesignation obj)
        {
            return new EmployeeDesignationModel
            {
                ED_ID = obj.ED_ID,
                ED_DESIGNATION = obj.ED_DESIGNATION,
                ED_FLSA_CODE = obj.ED_FLSA_CODE,
                ED_GL_ID = obj.ED_GL_ID,
                ED_HOUR_PER_WEEK = obj.ED_HOUR_PER_WEEK,
                ED_NO_POSITION = obj.ED_NO_POSITION,
                ED_SHORT_FORM = obj.ED_SHORT_FORM
            };
        }


        public EmployeeInfo Create(EmployeeInfoModel obj)
        {
            return new EmployeeInfo
            {
                Id = obj.Code,
                DepartmentId = obj.DepartmentId,
                Email = obj.Email,
                Phone = obj.Phone,
                Mobile = obj.Mobile,
                Website = obj.Website,
                BloodGroup = obj.BloodGroup,
                DateOfBirth = obj.DateOfBirth,
                Gender = obj.Gender,
                MaritalStatus = obj.MaritalStatus,
                MotherName = obj.MotherName,
                SpouseName = obj.SpouseName,
                BirthPlace = obj.BirthPlace,
                //Code = obj.Code,
                ContractPeriod = obj.ContractPeriod,
                ContractType = obj.ContractType,
                DateOfJob = obj.DateOfJob,
                EmployeeDesignationId = obj.EmployeeDesignationId,
                FamilyName = obj.FamilyName,
                FatherName = obj.FatherName,
                FatherOccupation = obj.FatherOccupation,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                ShiftId = obj.ShiftId,
                Badgenumber = obj.Badgenumber,
                MarriageDate = obj.MarriageDate,
                MiddleName = obj.MiddleName,
                MotherOccupation = obj.MotherOccupation,
                NationalId = obj.NationalId,
                Nationality = obj.Nationality,
                PassportNumber = obj.PassportNumber,
                PermanentAddress = obj.PermanentAddress,
                Photo = obj.Photo,
                PresentAddress = obj.PresentAddress,
                Religion = obj.Religion,
                SpouseOccupation = obj.SpouseOccupation,
                Tag = obj.Tag,
                TinNumber = obj.TinNumber
            };
        }

        public EmployeeInfoModel Create(EmployeeInfo obj)
        {
            return new EmployeeInfoModel
            {
                Code = obj.Id,
                Email = obj.Email,
                Phone = obj.Phone,
                Mobile = obj.Mobile,
                Website = obj.Website,
                BloodGroup = obj.BloodGroup,
                DateOfBirth = obj.DateOfBirth,
                Gender = obj.Gender,
                MaritalStatus = obj.MaritalStatus,
                MotherName = obj.MotherName,
                SpouseName = obj.SpouseName,
                BirthPlace = obj.BirthPlace,
                //Code = obj.Code,
                ContractPeriod = obj.ContractPeriod,
                ContractType = obj.ContractType,
                DateOfJob = obj.DateOfJob,
                DepartmentId = obj.DepartmentId,
                EmployeeDesignationId = obj.EmployeeDesignationId,
                FamilyName = obj.FamilyName,
                FatherName = obj.FatherName,
                FatherOccupation = obj.FatherOccupation,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                //ManagerId = obj.ManagerId,
                MarriageDate = obj.MarriageDate,
                MiddleName = obj.MiddleName,
                MotherOccupation = obj.MotherOccupation,
                NationalId = obj.NationalId,
                Nationality = obj.Nationality,
                PassportNumber = obj.PassportNumber,
                PermanentAddress = obj.PermanentAddress,
                Photo = obj.Photo,
                PresentAddress = obj.PresentAddress,
                Religion = obj.Religion,
                SpouseOccupation = obj.SpouseOccupation,
                Tag = obj.Tag,
                TinNumber = obj.TinNumber,
                ShiftId = obj.ShiftId,
                Badgenumber = obj.Badgenumber,
                //ShortForm = obj.EmployeeDesignation.ED_SHORT_FORM,
                //DepartmentName = obj.Department.Name,
                EducationModels = obj.Education.Select(Create).ToList()
            };
        }

        public BankTransaction Create(BankTransactionModel obj)
        {
            return new BankTransaction
            {
                BTR_ID = obj.BTR_ID,
                BTR_AMOUNT = obj.BTR_AMOUNT,
                BTR_BA_ACCOUNT_NAME = obj.BTR_BA_ACCOUNT_NAME,
                BTR_BA_CODE = obj.BTR_BA_CODE,
                BTR_BA_ID = obj.BTR_BA_ID,
                BTR_NARATION = obj.BTR_NARATION,
                BTR_PAY_TYPE = obj.BTR_PAY_TYPE,
                BTR_REC_DATE = obj.BTR_REC_DATE,
                BTR_REC_STATUS = obj.BTR_REC_STATUS,
                BTR_REC_USER = obj.BTR_REC_USER,
                BTR_TRANS_DATE = obj.BTR_TRANS_DATE,
                BTR_TXN_NO = obj.BTR_TXN_NO
            };
        }
        public BankTransactionModel Create(BankTransaction obj)
        {
            return new BankTransactionModel
            {
                BTR_ID = obj.BTR_ID,
                BTR_AMOUNT = obj.BTR_AMOUNT,
                BTR_BA_ACCOUNT_NAME = obj.BTR_BA_ACCOUNT_NAME,
                BTR_BA_CODE = obj.BTR_BA_CODE,
                BTR_BA_ID = obj.BTR_BA_ID,
                BTR_NARATION = obj.BTR_NARATION,
                BTR_PAY_TYPE = obj.BTR_PAY_TYPE,
                BTR_REC_DATE = obj.BTR_REC_DATE,
                BTR_REC_STATUS = obj.BTR_REC_STATUS,
                BTR_REC_USER = obj.BTR_REC_USER,
                BTR_TRANS_DATE = obj.BTR_TRANS_DATE,
                BTR_TXN_NO = obj.BTR_TXN_NO
            };
        }

        public BankAccount Create(BankAccountModel obj)
        {
            return new BankAccount
            {
                BA_Id = obj.BA_Id,
                BA_ACCOUNT_GL_CODE = obj.BA_ACCOUNT_GL_CODE,
                BA_ACCOUNT_NAME = obj.AccountName,
                BA_ACCOUNT_TYPE = obj.AccountyType,
                BA_BANK_ADDRESS = obj.BankAddress,
                BA_BANK_NAME = obj.BankName,
                BA_CODE = obj.Code,
                BA_STATUS = obj.BA_STATUS
            };
        }
        public BankAccountModel Create(BankAccount obj)
        {
            return new BankAccountModel
            {
                BA_Id = obj.BA_Id,
                BA_ACCOUNT_GL_CODE = obj.BA_ACCOUNT_GL_CODE,
                AccountName = obj.BA_ACCOUNT_NAME,
                AccountyType = obj.BA_ACCOUNT_TYPE,
                BankAddress = obj.BA_BANK_ADDRESS,
                BankName = obj.BA_BANK_NAME,
                Code = obj.BA_CODE,
                BA_STATUS = obj.BA_STATUS
            };
        }

        public Supplier Create(SupplierModel obj)
        {
            return new Supplier
            {
                SI_CODE = obj.Code,
                SI_NAME = obj.Name,
                SI_MAILING_ADDR = obj.MaillingAddress,
                SI_PERMANENT_ADDR = obj.PermanentAddress,
                SI_PHONE = obj.Phone,
                SI_EMAIL = obj.Email,
                SI_FAX = obj.Fax,
                SI_WEBSITE = obj.Website,
                SI_CONTACT_PERSON = obj.ContactPerson,
                SI_CURRENCY = obj.Currency,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                RecStatus = obj.RecStatus
            };
        }

        public SupplierModel Create(Supplier obj)
        {
            return new SupplierModel
            {
                Code = obj.SI_CODE,
                Name = obj.SI_NAME,
                MaillingAddress = obj.SI_MAILING_ADDR,
                PermanentAddress = obj.SI_PERMANENT_ADDR,
                Phone = obj.SI_PHONE,
                Email = obj.SI_EMAIL,
                Fax = obj.SI_FAX,
                Website = obj.SI_WEBSITE,
                ContactPerson = obj.SI_CONTACT_PERSON,
                Currency = obj.SI_CURRENCY,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                RecStatus = obj.RecStatus
            };
        }

        public SupplierPayment Create(SupplierPaymentModel obj)
        {
            return new SupplierPayment
            {
                Id = obj.Id,
                SI_CODE = obj.Code,
                InvoiceNo = obj.InvoiceNo,
                Amount = obj.Amount,
                TransNo = obj.TransNo,
                TransDate = obj.TransDate,
                TransType = obj.TransType,
                CheckNumber = obj.CheckNumber,
                CheckDate = obj.CheckDate,
                OpenDate = obj.OpenDate,
                ReceivedBy = obj.ReceivedBy,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                RecStatus = obj.RecStatus


            };
        }

        public SupplierPaymentModel Create(SupplierPayment obj)
        {
            return new SupplierPaymentModel
            {
                Id = obj.Id,
                Code = obj.SI_CODE,
                SupplierName = obj.Supplier.SI_NAME,
                InvoiceNo = obj.InvoiceNo,
                Amount = obj.Amount,
                TransNo = obj.TransNo,
                TransDate = obj.TransDate,
                TransType = obj.TransType,
                CheckNumber = obj.CheckNumber,
                CheckDate = obj.CheckDate,
                OpenDate = obj.OpenDate,
                ReceivedBy = obj.ReceivedBy,
                CreatedDate = obj.CreatedDate,
                CreatedBy = obj.CreatedBy,
                RecStatus = obj.RecStatus


            };
        }


        public GL_ACCOUNT Create(GL_ACCOUNTModel obj)
        {
            return new GL_ACCOUNT
            {
                GL_ID = obj.GL_ID,
                GL_CODE = obj.GL_CODE,
                GL_CATEGORY = obj.GL_CATEGORY,
                GL_CURRENCY = obj.GL_CURRENCY,
                GL_DIRECT_POSTING = obj.GL_DIRECT_POSTING,
                GL_HEAD_TYPE = obj.GL_HEAD_TYPE,
                GL_LEVEL = obj.GL_LEVEL,
                GL_MAP_CODE = obj.GL_MAP_CODE,
                GL_NAME = obj.GL_NAME,
                GL_PARENT_ID = obj.GL_PARENT_ID,
                GL_SWITCHABLE_PARENT_ID = obj.GL_SWITCHABLE_PARENT_ID,
                GL_TRANSACTION_SCOPE = obj.GL_TRANSACTION_SCOPE,
                GL_TRANSACTION_STATUS = obj.GL_TRANSACTION_STATUS,
                GL_VERIFY_DATE_TIME = obj.GL_VERIFY_DATE_TIME,
                GL_VERIFY_USER = obj.GL_VERIFY_USER
            };
        }
        public GL_ACCOUNTModel Create(GL_ACCOUNT obj)
        {
            return new GL_ACCOUNTModel
            {
                GL_ID = obj.GL_ID,
                GL_CODE = obj.GL_CODE,
                GL_CATEGORY = obj.GL_CATEGORY,
                GL_CURRENCY = obj.GL_CURRENCY,
                GL_DIRECT_POSTING = obj.GL_DIRECT_POSTING,
                GL_HEAD_TYPE = obj.GL_HEAD_TYPE,
                GL_LEVEL = obj.GL_LEVEL,
                GL_MAP_CODE = obj.GL_MAP_CODE,
                GL_NAME = obj.GL_NAME,
                GL_PARENT_ID = obj.GL_PARENT_ID,
                GL_SWITCHABLE_PARENT_ID = obj.GL_SWITCHABLE_PARENT_ID,
                GL_TRANSACTION_SCOPE = obj.GL_TRANSACTION_SCOPE,
                GL_TRANSACTION_STATUS = obj.GL_TRANSACTION_STATUS,
                GL_VERIFY_DATE_TIME = obj.GL_VERIFY_DATE_TIME,
                GL_VERIFY_USER = obj.GL_VERIFY_USER
            };
        }

        public TEST_CATEGORY Create(TestCategoryModel obj)
        {
            List<Test_Name> objTestNameModel = new List<Test_Name>();

            return new TEST_CATEGORY
            {
                TC_ID = obj.Id,
                TC_CODE = obj.Code,
                TC_DESCRIPTION = obj.Description,
                TC_TITLE = obj.Title,
                RecStatus = obj.RecordStatus,
                TestNames = objTestNameModel
            };
        }
        public TestCategoryModel Create(TEST_CATEGORY obj)
        {
            List<TestNameModel> objTestNameModel = new List<TestNameModel>();

            return new TestCategoryModel
            {
                Id = obj.TC_ID,
                Code = obj.TC_CODE,
                Description = obj.TC_DESCRIPTION,
                Title = obj.TC_TITLE,
                RecordStatus = obj.RecStatus,
                TestName = objTestNameModel
            };
        }

        public TestNameModel Create(Test_Name obj)
        {
            return new TestNameModel
            {
                Id = obj.T_ID,
                TestCategoryId = obj.T_TC_ID,
                Code = obj.T_CODE,
                Name = obj.T_NAME,
                TestCategoryTitle = obj.TEST_CATEGORY.TC_TITLE,
                Price = obj.T_Price,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                RecStatus = obj.RecStatus,
                Status = obj.Status
            };
        }

        public Test_Name Create(TestNameModel obj)
        {
            return new Test_Name
            {
                T_ID = obj.Id,
                T_TC_ID = obj.TestCategoryId,
                T_NAME = obj.Name,
                T_CODE = obj.Code,
                T_Price = obj.Price,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                RecStatus = obj.RecStatus,
                Status = obj.Status
            };
        }


        public TestRequestModel Create(TestRequest obj)
        {

            return new TestRequestModel
            {
                Id = obj.Id,
                TestNameId = obj.Test_NameId,
                TestName = obj.Test_Name.T_NAME,
                PatientId = obj.PatientId,
                PatientCode = obj.Patients.PatientCode,
                PatientName = obj.Patients.Name,
                Notes = obj.Notes,
                Status = obj.Status,
                CompletedBy = obj.CompletedBy,
                Department = obj.Department,
                DeuAmount = obj.DeuAmount,
                PaymentStatus = obj.PaymentStatus,
                VoucherNumber = obj.VoucherNumber

            };
        }

        public TestRequest Create(TestRequestModel obj)
        {

            return new TestRequest
            {
                Id = obj.Id,
                Test_NameId = obj.TestNameId,

                PatientId = obj.PatientId,

                Notes = obj.Notes,
                Status = obj.Status,
                CompletedBy = obj.CompletedBy,
                Department = obj.Department,
                DeuAmount = obj.DeuAmount,
                PaymentStatus = obj.PaymentStatus,
                VoucherNumber = obj.VoucherNumber
            };
        }
        public DEPARTMENT Create(DepartmentModel obj)
        {
            return new DEPARTMENT
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus
            };
        }

        public DepartmentModel Create(DEPARTMENT obj)
        {
            return new DepartmentModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus,
                //StockOutItemModel = obj.StockOutItems.Select(Create).ToList()
            };
        }

        public DepartmentDetailsForItem Create(DepartmentDetailsForItemModel obj)
        {
            return new DepartmentDetailsForItem
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                StockItemId = obj.StockOutItemId,
                DepartmentName = obj.DepartmentName,
                StockOutItemName = obj.StockOutItemName,
                RemainingQuantity = obj.RemainingQuantity,
                TotalQty = obj.TotalQty,
                Date = obj.Date
            };
        }

        public DepartmentDetailsForItemModel Create(DepartmentDetailsForItem obj)
        {
            return new DepartmentDetailsForItemModel
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                StockOutItemId = obj.StockItemId,
                DepartmentName = obj.DepartmentName,
                StockOutItemName = obj.StockOutItemName,
                RemainingQuantity = obj.RemainingQuantity,
                TotalQty = obj.TotalQty,
                Date = obj.Date
                //StockOutItemModel = obj.StockOutItems.Select(Create).ToList()
            };
        }



        public DrugDepartmentWiseStockIn Create(DrugDepartmentWiseStockInModel obj)
        {
            return new DrugDepartmentWiseStockIn
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                //DrugId = obj.DrugId,
                DepartmentName = obj.DepartmentName,
                //DrugName = obj.DrugName,
                //RemainingQuantity = obj.RemainingQuantity,
                TotalQty = obj.TotalQty,
                TransferQty = obj.TransferQty,
                Date = obj.Date,

            };
        }

        public DrugDepartmentWiseStockInModel Create(DrugDepartmentWiseStockIn obj)
        {
            return new DrugDepartmentWiseStockInModel
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                //DrugId = obj.DrugId,
                DepartmentName = obj.DepartmentName,
                //DrugName = obj.DrugName,
                //RemainingQuantity = obj.RemainingQuantity,
                TotalQty = obj.TotalQty,
                TransferQty = obj.TransferQty,
                Date = obj.Date,
                DrugDepartmentWiseStockInDetailsModel = obj.DrugDepartmentWiseStockInDetails.Select(Create).ToList()
            };
        }


        public DrugDepartmentWiseStockInDetails Create(DrugDepartmentWiseStockInDetailsModel obj)
        {
            return new DrugDepartmentWiseStockInDetails
            {
                Id = obj.Id,
                DrugDepartmentWiseStockInId = obj.DrugDepartmentWiseStockInId,
                UnitPrice = obj.UnitPrice,
                DrugId = obj.DrugId,
                DrugName = obj.DrugName,
                Quantity = obj.Quantity,
                CostPrice = obj.CostPrice,
                RemainingQuantity = obj.RemainingQuantity,
                SalePrice = obj.SalePrice,
                SubTotalPrice = obj.SubTotalPrice
            };
        }

        public DrugDepartmentWiseStockInDetailsModel Create(DrugDepartmentWiseStockInDetails obj)
        {
            return new DrugDepartmentWiseStockInDetailsModel
            {
                Id = obj.Id,
                DrugDepartmentWiseStockInId = obj.DrugDepartmentWiseStockInId,
                UnitPrice = obj.UnitPrice,
                DrugId = obj.DrugId,
                DrugName = obj.DrugName,
                Quantity = obj.Quantity,
                CostPrice = obj.CostPrice,
                RemainingQuantity = obj.RemainingQuantity,
                SalePrice = obj.SalePrice,
                SubTotalPrice = obj.SubTotalPrice
            };
        }
        public ItemStockOutDetails Create(ItemStockOutDetailsModel obj)
        {
            return new ItemStockOutDetails
            {
                Id = obj.Id,
                ItemStockOutId = obj.ItemStockOutId,
                StoreItemId = obj.StoreItemId,

                Quantity = obj.Quantity,
                StoreItemName = obj.StoreItemName
            };
        }

        public ItemStockOutDetailsModel Create(ItemStockOutDetails obj)
        {
            return new ItemStockOutDetailsModel
            {
                Id = obj.Id,
                ItemStockOutId = obj.ItemStockOutId,
                StoreItemId = obj.StoreItemId,
                StoreItemName = obj.StoreItemName,
                Quantity = obj.Quantity,
                //StockOutItemName = obj.StockOutItemName
                //StockOutItemModel = obj.StockOutItems.Select(Create).ToList()
            };
        }

        public ItemStockOut Create(ItemStockOutModel obj)
        {
            return new ItemStockOut
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                Purpose = obj.Purpose,
                TotalQty = obj.TotalQty,
                PurposeBy = obj.PurposeBy,
                Date = obj.Date,
            };
        }

        public ItemStockOutModel Create(ItemStockOut obj)
        {
            return new ItemStockOutModel
            {
                Id = obj.Id,
                MemoNo = obj.MemoNo,
                DepartmentId = obj.DepartmentId,
                DepartmentName = obj.Department.Name,
                Purpose = obj.Purpose,
                TotalQty = obj.TotalQty,
                PurposeBy = obj.PurposeBy,
                Date = obj.Date,
                ItemStockOutDetailsModel = obj.ItemStockOutDetails.Select(Create).ToList()
            };
        }


        public DrugModel Create(DRUG obj)
        {
            return new DrugModel
            {
                D_ID = obj.D_ID,
                D_DM_ID = obj.D_DM_ID,
                D_DPT_ID = obj.D_DPT_ID,
                D_TRADE_NAME = obj.D_TRADE_NAME,
                D_DM_Name = obj.DRUG_MANUFACTURER.DM_NAME,
                D_DPT_Name = obj.DURG_PRESENTATION_TYPE.DPT_DESCRIPTION,
                D_GENERIC_NAME = obj.D_GENERIC_NAME,
                D_DISPENSE_FROM = obj.D_DISPENSE_FROM,
                D_PACK_QTY = obj.D_PACK_QTY,
                D_REORDER_LEVEL = obj.D_REORDER_LEVEL,
                D_DISCOUNT = obj.D_DISCOUNT,
                D_STATUS = obj.D_STATUS,
                D_UNIT_STRENGTH = obj.D_UNIT_STRENGTH,
                Discount = obj.Discount,
                Tax = obj.Tax,
                SalePrice = obj.SalePrice

            };
        }

        public DRUG Create(DrugModel obj)
        {
            return new DRUG
            {
                D_ID = obj.D_ID,
                D_DM_ID = obj.D_DM_ID,
                D_DPT_ID = obj.D_DPT_ID,
                D_TRADE_NAME = obj.D_TRADE_NAME,

                D_GENERIC_NAME = obj.D_GENERIC_NAME,
                D_DISPENSE_FROM = obj.D_DISPENSE_FROM,
                D_PACK_QTY = obj.D_PACK_QTY,
                D_REORDER_LEVEL = obj.D_REORDER_LEVEL,
                D_DISCOUNT = obj.D_DISCOUNT,
                D_STATUS = obj.D_STATUS,
                D_UNIT_STRENGTH = obj.D_UNIT_STRENGTH,
                Discount = obj.Discount,
                Tax = obj.Tax,
                SalePrice = obj.SalePrice
            };
        }


        public DrugManufacturerSummaryModel CreateMfg(DRUG_MANUFACTURER obj)
        {
            return new DrugManufacturerSummaryModel
            {
                Id = obj.DM_ID,
                Name = obj.DM_NAME,
                Type = obj.DM_TYPE,
                ContactPerson = obj.DM_CONTACT_PERSON,
                Address = obj.DM_ADDRESS,
                Mobile = obj.DM_MOBILE,
                Phone = obj.DM_PHONE,
                Fax = obj.DM_FAX,
                Email = obj.DM_EMAIL,
                Web = obj.DM_WEB,
                Status = obj.DM_STATUS
            };

        }

        public DRUG_MANUFACTURER Create(DrugMenufacturerModel obj)
        {
            return new DRUG_MANUFACTURER
            {
                DM_ID = obj.DM_ID,
                DM_NAME = obj.DM_NAME,
                DM_ADDRESS = obj.DM_ADDRESS,
                DM_EMAIL = obj.DM_EMAIL,
                DM_MOBILE = obj.DM_MOBILE,
                DM_FAX = obj.DM_FAX,
                DM_PHONE = obj.DM_PHONE,
                DM_CONTACT_PERSON = obj.DM_CONTACT_PERSON,
                DM_STATUS = obj.DM_STATUS,
                DM_TYPE = obj.DM_TYPE,
                DM_WEB = obj.DM_WEB,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus

            };
        }
        public DrugMenufacturerModel Create(DRUG_MANUFACTURER obj)
        {
            List<DrugModel> objDrugModel = new List<DrugModel>();

            return new DrugMenufacturerModel
            {
                DM_ID = obj.DM_ID,
                DM_NAME = obj.DM_NAME,
                DM_ADDRESS = obj.DM_ADDRESS,
                DM_EMAIL = obj.DM_EMAIL,
                DM_MOBILE = obj.DM_MOBILE,
                DM_FAX = obj.DM_FAX,
                DM_PHONE = obj.DM_PHONE,
                DM_CONTACT_PERSON = obj.DM_CONTACT_PERSON,
                DM_STATUS = obj.DM_STATUS,
                DM_TYPE = obj.DM_TYPE,
                DM_WEB = obj.DM_WEB,
                Drug = objDrugModel,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                ModifiedBy = obj.ModifiedBy,
                ModifiedDate = obj.ModifiedDate,
                RecStatus = obj.RecStatus

            };
        }


        public DURG_PRESENTATION_TYPE Create(DrugPresentationTypeModel obj)
        {
            return new DURG_PRESENTATION_TYPE
            {
                DPT_ID = obj.DPT_ID,
                DPT_DESCRIPTION = obj.DPT_DESCRIPTION
            };
        }

        public DrugPresentationTypeModel Create(DURG_PRESENTATION_TYPE obj)
        {
            List<DrugModel> objDrugModel = new List<DrugModel>();
            return new DrugPresentationTypeModel
            {
                DPT_ID = obj.DPT_ID,
                DPT_DESCRIPTION = obj.DPT_DESCRIPTION,
                DrugModels = objDrugModel,
            };
        }

        public InsuranceCompany Create(InsuranceCompanyModel obj)
        {
            return new InsuranceCompany
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Email = obj.Email,
                Website = obj.Website

            };
        }
        public InsuranceCompanyModel Create(InsuranceCompany obj)
        {

            return new InsuranceCompanyModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Email = obj.Email,
                Website = obj.Website,
                InsurancePlanModels = obj.Insurance.Select(Create).ToList()

            };
        }


        public InsurancePlan Create(InsurancePlanModel obj)
        {
            return new InsurancePlan
            {
                Id = obj.Id,
                Name = obj.Name,
                InsuranceCompanyId = obj.InsuranceCompanyId,

            };
        }


        public InsurancePlanModel Create(InsurancePlan obj)
        {
            return new InsurancePlanModel
            {
                Id = obj.Id,
                Name = obj.Name,
                InsuranceCompanyId = obj.InsuranceCompanyId,
                InsuranceCompanyName = obj.InsuranceCompany.Name
            };
        }

    }
}
