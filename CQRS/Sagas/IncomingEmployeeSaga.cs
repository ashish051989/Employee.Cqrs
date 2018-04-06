//using CQRS.Commands;
//using Rebus.Bus;
//using Rebus.Sagas;
//using Rebus.Handlers;
//using Repository.ResourceAccess.ApplicationRepository;
//using System;
//using System.Threading.Tasks;

//namespace CQRS.Sagas
//{
//    public class IncomingEmployeeSaga : IHandleMessages<SaveEmployeeCommand>,
//        IHandleMessages<IncomingEmployeeAddedCommand>
//    {
//        private readonly IBus bus;
//        private readonly IEmployeeRepository empRepository;

//        public IncomingEmployeeSaga(IBus bus,
//            IEmployeeRepository empRepository)
//        {
//            this.bus = bus;
//            this.empRepository = empRepository;
//        }

//        public Task Handle(SaveEmployeeCommand message)
//        {
//            return Task.Factory.StartNew(() =>
//            {
//                //var emp = Employee.Factory.Register(
//                //    message.EmpId,
//                //    message.EmpName
//                //    );
//                //bus.Publish("Pulished");
//            });
//        }

//        public Task Handle(IncomingEmployeeAddedCommand message)
//        {
//            return Task.Factory.StartNew(() =>
//            {
//                //this.MarkAsComplete();
//            });
//        }

//        //protected override void CorrelateMessages(ICorrelationConfig<IncomingEmployeeSagaData> config)
//        //{
//        //    try
//        //    {
//        //        config.Correlate<SaveEmployeeCommand>(
//        //       message => message.EmpId,
//        //       sagaData => sagaData.EmpId);
//        //    }
//        //    catch(Exception ex)
//        //    {

//        //    }
           
//        //}

//        public class IncomingEmployeeSagaData : SagaData
//        {
//            public Guid EmpId { get; set; }
//        }
//    }
//}
