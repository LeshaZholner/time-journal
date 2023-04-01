
import { TimeCalendarBody } from "./components/body";
import { TimeCalendarHeader } from "./components/header";
import './styles.scss';

const TimeCalendar = () => {
  const tasks = mockTasks;
  const userCalendar = mockUserCalendar;

  return (
    <div className='time-calendar'>
      <TimeCalendarHeader
        userCalendar={userCalendar}
      />
      <TimeCalendarBody
        tasks={tasks}
        userCalendar={userCalendar}
      />
    </div>
  )
}

export { TimeCalendar };

const mockTasks = [
  {
    name: "Task-1",
    workloads: [
      {
        date: "2023-03-27",
        duration: 4
      },
      {
        date: "2023-03-28",
        duration: 4
      },
      {
        date: "2023-03-29",
        duration: 4
      }
    ]
  },
  {
    name: "Task-2",
    workloads: [
      {
        date: "2023-03-27",
        duration: 4
      },
      {
        date: "2023-03-29",
        duration: 4
      },
    ]
  }
]

const mockUserCalendar = {
  days: [
    {
      day: "2023-03-26",
      dayOfWeek: "Sunday",
      workDay: false,
    },
    {
      day: "2023-03-27",
      dayOfWeek: "Monday",
      workDay: true,
    },
    {
      day: "2023-03-28",
      dayOfWeek: "Tuesday",
      workDay: true,
    },
    {
      day: "2023-03-29",
      dayOfWeek: "Wednesday",
      workDay: true,
    },
    {
      day: "2023-03-30",
      dayOfWeek: "Thursday",
      workDay: true,
    },
    {
      day: "2023-03-31",
      dayOfWeek: "Friday",
      workDay: true,
    },
    {
      day: "2023-04-01",
      dayOfWeek: "Saturday",
      workDay: false,
    },
  ]
}