import clsx from 'clsx';
import './App.css'

const TimeJournalRow = ({ children }) => {
  return (
    <div className='time-journal-row'>
      {children}
    </div>
  )
}

const TimeJournalLeftPart = ({ children }) => {
  return (
    <div className='time-journal-left-part'>
      {children}
    </div>
  )
}

const TimeJournalRightPart = ({ children }) => {
  return (
    <div className='time-journal-right-part'>
      {children}
    </div>
  )
}

const TimeJournalCellWrapper = ({ classes, children }) => {
  return (
    <div className={clsx('time-journal-cell-wrapper', classes)}>
      {children}
    </div>
  )
}

const TimeJournalHeaderCell = ({ day, dayOfWeek }) => {
  return (
    <TimeJournalCellWrapper
      classes='time-journal-cell-wrapper-header'
    >
      <div className='time-journal-header-cell'>
        <span className='time-journal-header-cell-day'>{day}</span>
        <span className='time-journal-header-cell-dayOfWeek'>{dayOfWeek}</span>
      </div>
    </TimeJournalCellWrapper>
  )
}

const TimeJournalWorkloadCell = ({ value }) => {
  return (
    <TimeJournalCellWrapper
      classes='time-journal-cell-wrapper-workload'
    >
      <div className='time-journal-workload-cell'>
        <input
          className='time-journal-workload-cell-input'
          defaultValue={value}
        />
      </div>
    </TimeJournalCellWrapper>
  )
}

const TimeJournalHeader = () => {
  const userCalendar = mockUserCalendar;

  return (
    <div className='time-journal-header'>
      <TimeJournalRow>
        <TimeJournalLeftPart>
          <div className='time-journal-left-header-container'>
            <div className='header-title'>Task name</div>
          </div>
        </TimeJournalLeftPart>
        <TimeJournalRightPart>
          {
            userCalendar.days.map(day => {
              return (
                <TimeJournalHeaderCell
                  day={new Date(day.day).getDate()}
                  dayOfWeek={day.dayOfWeek.slice(0, 2)}
                />
              )
            })
          }
        </TimeJournalRightPart>
      </TimeJournalRow>
    </div>
  )
}

const TimeJournalBody = () => {
  const tasks = mockTasks;
  const userCalendar = mockUserCalendar;

  return (
    <div className='time-journal-body'>
      {
        tasks.map(task => {
          return (
            <TimeJournalRow key={task.name}>
              <TimeJournalLeftPart>
                <div className='time-journal-left-activity-container'>
                  <div className='activity-title'>{task.name}</div>
                </div>
              </TimeJournalLeftPart>
              <TimeJournalRightPart>
                {
                  userCalendar.days.map(day => {
                    const workload = task.workloads.find(x => x.date == day.day)?.duration || null;
                    return (
                      <TimeJournalWorkloadCell
                        value={workload}
                      />
                    )
                  })
                }
              </TimeJournalRightPart>
            </TimeJournalRow>
          )
        })
      }
    </div>
  )
}

function App() {
  return (
    <div className="App">
      <div className='time-journal'>
        <TimeJournalHeader />
        <TimeJournalBody />
      </div>
    </div>
  )
}

export default App


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