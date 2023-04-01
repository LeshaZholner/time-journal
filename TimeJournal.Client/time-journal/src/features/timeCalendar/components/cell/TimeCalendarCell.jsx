import clsx from "clsx";
import './styles.scss';

const TimeCalendarCell = ({ classes, children }) => {
  return (
    <div className={clsx('time-calendar-cell', classes)}>
      {children}
    </div>
  )
}

export { TimeCalendarCell };