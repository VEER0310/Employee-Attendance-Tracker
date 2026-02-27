export interface Policy {
  id: number;
  name: string;
  minDailyHours: number;
}

export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  policyId: number;
  policyName: string;
}

export interface CreateEmployee {
  policyId: number;
  firstName: string;
  lastName: string;
  email: string;
}

export interface CreateAttendance {
  employeeId: number;
  attendanceDate: string;  // date ( YYYY-MM-DD )
  status: string;          // Present 6 k Absent
  hoursWorked: number;
}

export interface DailyReport {
  employeeId: number;
  fullName: string;
  policyName: string;
  minDailyHours: number;
  attendanceDate: string;
  status: string;
  hoursWorked: number;
  dailyFlag: string;       // OK 6 k PolicyViolation
}