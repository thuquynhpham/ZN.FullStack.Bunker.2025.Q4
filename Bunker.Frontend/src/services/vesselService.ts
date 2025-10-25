import api from './api'
import type { 
  Vessel, 
  CreateVesselRequest, 
  UpdateVesselRequest, 
  VesselListResponse, 
  VesselListQuery,
  ApiResponse 
} from '@/types'

export class VesselService {
  async getAllVessels(query: VesselListQuery = {}): Promise<VesselListResponse> {
    const params = {
      pageNumber: query.pageNumber || 1,
      pageSize: query.pageSize || 10,
      ...query
    }
    
    const response = await api.get<VesselListResponse>('/vessels/get-all', params)
    return response
  }

  async getVesselById(id: number): Promise<Vessel> {
    const response = await api.get<Vessel>(`/vessels/get-by-id/${id}`)
    return response
  }

  async createVessel(vessel: CreateVesselRequest): Promise<ApiResponse<Vessel>> {
    const response = await api.post<ApiResponse<Vessel>>('/vessels/create', vessel)
    return response
  }

  async updateVessel(id: number, vessel: UpdateVesselRequest): Promise<ApiResponse<Vessel>> {
    const response = await api.put<ApiResponse<Vessel>>(`/vessels/update/${id}`, vessel)
    return response
  }

  async deleteVessel(id: number): Promise<ApiResponse<void>> {
    const response = await api.delete<ApiResponse<void>>(`/vessels/delete/${id}`)
    return response
  }
}

export default new VesselService()
