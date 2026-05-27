import { API_BASE_URL, TENANT_HEADER } from '@/utils/constants';

export type ApiResponse<T> = {
  success: boolean;
  message: string;
  data: T;
  errors: string[];
};

type RequestOptions = RequestInit & {
  tenantId?: string;
};

export async function apiClient<T>(
  path: string,
  options: RequestOptions = {},
): Promise<ApiResponse<T>> {
  const { tenantId, headers, ...rest } = options;

  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...rest,
    headers: {
      'Content-Type': 'application/json',
      ...(tenantId ? { [TENANT_HEADER]: tenantId } : {}),
      ...headers,
    },
  });

  if (!response.ok) {
    throw new Error(`API request failed: ${response.status}`);
  }

  return response.json() as Promise<ApiResponse<T>>;
}

export async function checkHealth(): Promise<{ status: string }> {
  const response = await fetch(`${API_BASE_URL}/health`);
  if (!response.ok) {
    throw new Error('Health check failed');
  }
  return response.json() as Promise<{ status: string }>;
}
