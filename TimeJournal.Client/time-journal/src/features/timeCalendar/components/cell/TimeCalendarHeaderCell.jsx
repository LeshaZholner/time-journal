import { TimeCalendarCell } from "./TimeCalendarCell";
import './styles.scss';

const TimeCalendarHeaderCell = ({ day, dayOfWeek }) => {
  return (
    <TimeCalendarCell
      classes='time-calendar-cell-wrapper-header'
    >
      <div className='time-calendar-header-cell'>
        <span className='time-calendar-header-cell-day'>{day}</span>
        <span className='time-calendar-header-cell-dayOfWeek'>{dayOfWeek}</span>
      </div>
    </TimeCalendarCell>
  )
}

export { TimeCalendarHeaderCell };
