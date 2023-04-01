import { TimeCalendarWorkloadCell } from '../cell';
import {
  TimeCalendarRow,
  TimeCalendarLeftPart,
  TimeCalendarRightPart
} from '../containers';
import './styles.scss';

const TimeCalendarBody = ({ tasks, userCalendar }) => {
  return (
    <div className='time-calendar-body'>
      {
        tasks.map(task => {
          return (
            <TimeCalendarRow key={task.name}>
              <TimeCalendarLeftPart>
                <div className='time-calendar-left-activity-container'>
                  <div className='activity-title'>{task.name}</div>
                </div>
              </TimeCalendarLeftPart>
              <TimeCalendarRightPart>
                {
                  userCalendar.days.map(day => {
                    const workload = task.workloads.find(x => x.date == day.day)?.duration || null;
                    return (
                      <TimeCalendarWorkloadCell
                        key={day.day}
                        value={workload}
                      />
                    )
                  })
                }
              </TimeCalendarRightPart>
            </TimeCalendarRow>
          )
        })
      }
    </div>
  )
}

export { TimeCalendarBody };