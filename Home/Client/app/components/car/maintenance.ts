import { MaintenanceType } from "./maintenance-type";

export interface Maintenance {
    maintenanceId: number;
    carId: number;
    typeId: number;
    date: Date;
    kilometers: number;
    type: MaintenanceType;
}