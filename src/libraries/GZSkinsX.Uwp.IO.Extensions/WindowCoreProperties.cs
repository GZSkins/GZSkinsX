// Copyright 2022 - 2023 GZSkins, Inc. All rights reserved.
// Licensed under the Mozilla Public License, Version 2.0 (the "License.txt").
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace GZSkinsX.Uwp.IO.Extensions;

/// <summary>
/// 
/// </summary>
public enum WindowCoreProperties
{
    /// <summary>
    /// ָʾ��ȡ�Ự�Ĺ�ϣֵ��
    /// </summary>
    System_AcquisitionID,
    /// <summary>
    /// 
    /// </summary>
    System_ApplicationDefinedProperties,
    /// <summary>
    /// �������ļ������Ӧ�ó�������ơ� ����ʹ�ð汾������ʶӦ�ó�����ض��汾��
    /// </summary>
    System_ApplicationName,
    /// <summary>
    /// Ӧ�������ı�ǡ� �ļ����һ����д��ȷ���������ʶ����
    /// </summary>
    System_AppZoneIdentifier,
    /// <summary>
    /// ��ʾ�ĵ������߻����ߡ�
    /// </summary>
    System_Author,
    /// <summary>
    /// 
    /// </summary>
    System_CachedFileUpdaterContentIdForConflictResolution,
    /// <summary>
    /// 
    /// </summary>
    System_CachedFileUpdaterContentIdForStream,
    /// <summary>
    /// �ܴ洢�ռ��������ֽڱ�ʾ����
    /// </summary>
    System_Capacity,
    /// <summary>
    /// �����á� �ɷ�����ĵ����ļ���������
    /// </summary>
    System_Category,
    /// <summary>
    /// ���ӵ��ļ���ע�ͣ�ͨ�����û���ӡ�
    /// </summary>
    System_Comment,
    /// <summary>
    /// ��˾�򷢲��ߡ�
    /// </summary>
    System_Company,
    /// <summary>
    /// ����ļ����ڵļ���������ơ�
    /// </summary>
    System_ComputerName,
    /// <summary>
    /// �����������͵��б�
    /// </summary>
    System_ContainedItems,
    /// <summary>
    /// 
    /// </summary>
    System_ContentStatus,
    /// <summary>
    /// 
    /// </summary>
    System_ContentType,
    /// <summary>
    /// ��Ϊ�ַ����洢�İ�Ȩ��Ϣ��
    /// </summary>
    System_Copyright,
    /// <summary>
    /// �������ļ���Ӧ�ó���� AppId��
    /// </summary>
    System_CreatorAppId,
    /// <summary>
    /// �ṩӰ�� UI �ؼ�����Ϊ��ѡ���Щ�ؼ�ʹ�� <seealso cref="System_CreatorAppId">System.CreatorAppId</seealso> ��ָ����Ӧ�������ļ���
    /// </summary>
    System_CreatorOpenWithUIOptions,
    /// <summary>
    /// ���ݶ����ʽ�� һ���ַ���ֵ����ֵ�Ǽ������ʽ���ơ�
    /// </summary>
    System_DataObjectFormat,
    /// <summary>
    /// ָʾ�ϴη�����Ŀ��ʱ�䡣 ���������Ѻ�����Ϊ��access����
    /// </summary>
    System_DateAccessed,
    /// <summary>
    /// �ļ���ý��Ļ�ȡ���ڡ�
    /// </summary>
    System_DateAcquired,
    /// <summary>
    /// �ļ����ϴδ浵�����ڡ�
    /// </summary>
    System_DateArchived,
    /// <summary>
    /// 
    /// </summary>
    System_DateCompleted,
    /// <summary>
    /// ���ڵ�ǰ���ڵ��ļ�ϵͳ�ϴ��������ں�ʱ�䡣
    /// </summary>
    System_DateCreated,
    /// <summary>
    /// �ļ����뵽ר��Ӧ�ó������ݿ�����ں�ʱ�䡣
    /// </summary>
    System_DateImported,
    /// <summary>
    /// �ϴ��޸�������ں�ʱ�䡣 ���������Ѻ�����Ϊ��write����
    /// </summary>
    System_DateModified,
    /// <summary>
    /// ������ʾΪͼ�꣬����λ���Ƿ��ǿ������ߺͷ������ߵ�Ĭ�ϱ���λ��
    /// </summary>
    System_DefaultSaveLocationDisplay,
    /// <summary>
    /// 
    /// </summary>
    System_DueDate,
    /// <summary>
    /// 
    /// </summary>
    System_EndDate,
    /// <summary>
    /// δ�洢������е����ԣ��������Բ��ð��� SERIALIZEDPROPSTORAGE ��������ʽ��
    /// </summary>
    System_ExpandoProperties,
    /// <summary>
    /// 
    /// </summary>
    System_FileAllocationSize,
    /// <summary>
    /// ������ԡ� ��Щֵ��Ч�� <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataa">WIN32_FIND_DATA</see> �ṹ�� dwFileAttributes ��Ա��ʶ���ֵ��
    /// </summary>
    System_FileAttributes,
    /// <summary>
    /// 
    /// </summary>
    System_FileCount,
    /// <summary>
    /// �ļ����û��Ѻ�˵����
    /// </summary>
    System_FileDescription,
    /// <summary>
    /// ��ʶ�����ļ�������ļ���չ��������ǰ���ڡ�
    /// </summary>
    System_FileExtension,
    /// <summary>
    /// Ψһ���ļ� ID��Ҳ��Ϊ�ļ����úš�
    /// </summary>
    System_FileFRN,
    /// <summary>
    /// �ļ�������������չ����
    /// </summary>
    System_FileName,
    /// <summary>
    /// Null ��ʾ��������£� (�ļ��ѻ�) ���á� ���������������ĳЩ���ݿ����ѻ�ʹ�õ��ļ��У���Щ�ļ��п��ܲ����á�
    /// </summary>
    System_FileOfflineAvailabilityStatus,
    /// <summary>
    /// �ļ��������ߣ����ļ�ϵͳ���ơ�
    /// </summary>
    System_FileOwner,
    /// <summary>
    /// ����ռλ���ļ���״̬��־��
    /// </summary>
    System_FilePlaceholderStatus,
    /// <summary>
    /// 
    /// </summary>
    System_FileVersion,
    /// <summary>
    /// ������Ϊ�ֽڻ����� �� <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-win32_find_dataa">WIN32_FIND_DATA</see> �ṹ�� ���𽫴����������κ�����Ŀ�ġ�
    /// </summary>
    System_FindData,
    /// <summary>
    /// 
    /// </summary>
    System_FlagColor,
    /// <summary>
    /// <see href="https://learn.microsoft.com/zh-cn/windows/win32/properties/props-system-flagcolor">System.FlagColor</see> ���û��Ѻ���ʽ�� ��ֵ�������Ա�̷�ʽ���з�����
    /// </summary>
    System_FlagColorText,
    /// <summary>
    /// ��־��״̬�� ֵ�� (0=none 1=white 2=Red) ��
    /// </summary>
    System_FlagStatus,
    /// <summary>
    /// <see href="https://learn.microsoft.com/zh-cn/windows/win32/properties/props-system-flagstatus">System.FlagStatus</see> ���û��Ѻ���ʽ�� ��ֵ�������Ա�̷�ʽ���з�����
    /// </summary>
    System_FlagStatusText,
    /// <summary>
    /// �����Ա�ʾ�洢�ṩ����ָ���Ĵ��ļ����д洢���������͡�ÿ���ļ������ͱ����� <seealso cref="System_Kind">System.Kind</seealso>, <seealso cref="System_FolderKind">System.FolderKind</seealso> ָ������ֵ֪֮һ��ֻ�����ԣ���ֻ���ɴ洢�ṩ������¡�
    /// </summary>
    System_FolderKind,
    /// <summary>
    /// ������������ <seealso cref="System_ItemNameDisplay">System.ItemNameDisplay</seealso>����������ļ������ã������ļ��������Խ�Ϊ�ա� ������ڽ��ļ����ļ���������һ��������������ļ����ļ��С� �� <seealso cref="System_ItemDate">System.ItemDate</seealso> �����ڶ��������ʱ���������ɽ���������ļ������Ȱ���������Ȼ������������ļ���
    /// </summary>
    System_FolderNameDisplay,
    /// <summary>
    /// ���еĿ��ÿռ��������ֽ�Ϊ��λ����
    /// </summary>
    System_FreeSpace,
    /// <summary>
    /// ����������ָ��Ӧ�����ܹ㷺��Ӧ��������������Դ��������Ч���Ե������ʡ���Ӧ������Դ��������
    /// </summary>
    System_FullText,
    /// <summary>
    /// ��ĸ����Ŷȹؼ��֡�
    /// </summary>
    System_HighKeywords,
    /// <summary>
    /// ͼ��������ơ�
    /// </summary>
    System_ImageParsingName,
    /// <summary>
    /// 
    /// </summary>
    System_Importance,
    /// <summary>
    /// <see href="https://learn.microsoft.com/zh-cn/windows/win32/properties/props-system-importance">System.Importance</see> ���û��Ѻ���ʽ�� ��ֵ�����Ա�̷�ʽ�����ġ�
    /// </summary>
    System_ImportanceText,
    /// <summary>
    /// ��ʶ�����Ƿ�Ϊ������
    /// </summary>
    System_IsAttachment,
    /// <summary>
    /// ��ʶ��������߿��Ĭ�ϱ���λ�á�
    /// </summary>
    System_IsDefaultNonOwnerSaveLocation,
    /// <summary>
    /// ��ʶ�������ߵ�Ĭ�ϱ���λ�á�
    /// </summary>
    System_IsDefaultSaveLocation,
    /// <summary>
    /// 
    /// </summary>
    System_IsDeleted,
    /// <summary>
    /// ��ʶ���Ƿ��Ѽ��ܡ�
    /// </summary>
    System_IsEncrypted,
    /// <summary>
    /// 
    /// </summary>
    System_IsFlagged,
    /// <summary>
    /// 
    /// </summary>
    System_IsFlaggedComplete,
    /// <summary>
    /// ��ʶ��Ϣ�Ƿ�����ȫ���ա� ��ֵ��ĳЩ��������һ��ʹ�á�
    /// </summary>
    System_IsIncomplete,
    /// <summary>
    /// ��ʶ��ĳ��λ����ӵ���ʱ�Ƿ��ѱ������������ػ�Զ�̣���
    /// </summary>
    System_IsLocationSupported,
    /// <summary>
    /// ��ʶ shell �ļ����Ƿ�̶�����������
    /// </summary>
    System_IsPinnedToNameSpaceTree,
    /// <summary>
    /// ��ʶ���Ƿ��Ѷ�ȡ��
    /// </summary>
    System_IsRead,
    /// <summary>
    /// ��ʶλ�û���Ƿ��������
    /// </summary>
    System_IsSearchOnlyItem,
    /// <summary>
    /// ָʾ���Ƿ�Ϊ��Ч�� SendTo Ŀ�ꡣ ����Ϣ��ĳЩ Shell �ļ����ṩ��
    /// </summary>
    System_IsSendToTarget,
    /// <summary>
    /// ָʾ���Ƿ��� �������Ǽ̳� ACL��
    /// </summary>
    System_IsShared,
    /// <summary>
    /// ������������ߵķ����б� ���磬������Ŀ����������������Ŀ���ߡ�
    /// </summary>
    System_ItemAuthors,
    /// <summary>
    /// ��������͡�
    /// </summary>
    System_ItemClassType,
    /// <summary>
    /// ��Ŀ����Ҫ��Ȥ���ڡ� ���磬������Ƭ��������ӳ�䵽 <see href="https://learn.microsoft.com/zh-cn/windows/win32/properties/props-system-photo-datetaken">System.Photo.DateTaken</see>��
    /// </summary>
    System_ItemDate,
    /// <summary>
    /// ��Ŀ�ĸ��ļ��е��û��Ѻ���ʾ���ơ�
    /// </summary>
    System_ItemFolderNameDisplay,
    /// <summary>
    /// ��Ŀ�ĸ��ļ��е��û��Ѻ���ʾ·����
    /// </summary>
    System_ItemFolderPathDisplay,
    /// <summary>
    /// ��Ŀ�ĸ��ļ��е��û��Ѻ���ʾ·����
    /// </summary>
    System_ItemFolderPathDisplayNarrow,
    /// <summary>
    /// <see href="https://learn.microsoft.com/zh-cn/windows/win32/properties/props-system-itemnamedisplay">System.ItemNameDisplay</see> ���ԵĻ����ơ�
    /// </summary>
    System_ItemName,
    /// <summary>
    /// ������������ʽ����ʾ���ơ�
    /// </summary>
    System_ItemNameDisplay,
    /// <summary>
    /// �������� <seealso cref="System_ItemNameDisplay"/>��ֻ�����Ӳ������ļ���չ����
    /// </summary>
    System_ItemNameDisplayWithoutExtension,
    /// <summary>
    /// ��Ŀ��ǰ׺������������ǰ׺��Re������ͷ�ĵ����ʼ���
    /// </summary>
    System_ItemNamePrefix,
    /// <summary>
    /// ���ַ���Ӧ����Ϊ�� CJK �������ã�CHS ƴ����JPN ƽ������KOR ���ĵȣ��ж������ʾ���Ƶ�ƴ���汾�����ֶεĵ�һ���ַ������ڰ�����ĸ�����ƽ��з��顣���ڴ������ CJK ���ԣ�����Ҫ���ô��ֶΣ�����������£���ʹ�� <seealso cref="System_ItemNameDisplay"/>�������ǣ������Ҫ���Ƿ�����ĸ�����磬ɾ����a���͡�the����ǰ�����£���������ڴ˴��ṩ�����ַ�����
    /// </summary>
    System_ItemNameSortOverride,
    /// <summary>
    /// ����Ŀ��������Ա�ķ����б�Ͳ����
    /// </summary>
    System_ItemParticipants,
    /// <summary>
    /// ����û��Ѻ���ʾ·����
    /// </summary>
    System_ItemPathDisplay,
    /// <summary>
    /// ����û��Ѻ���ʾ·����
    /// </summary>
    System_ItemPathDisplayNarrow,
    /// <summary>
    /// ������������͡� ��ֵ�������û���ʾ���� <seealso cref="System_ItemType">System.ItemType</seealso> ��ȣ�<seealso cref="System_ItemType">System.ItemType</seealso> ͨ�������������о�����ͬͨ�����ݸ�ʽ�����࣬<seealso cref="System_ItemType">System.ItemType</seealso> ��������ĸ������ݻ���;���졣���磬�����Կ����ڽ� System.ItemType = ��jpg����ʶΪ <seealso cref="System_ItemType">System.ItemType</seealso> = ��Panorama���� <seealso cref="System_ItemType">System.ItemType</seealso> = ��Smart Shot�����
    /// </summary>
    System_ItemSubType,
    /// <summary>
    /// ��Ŀ�Ĺ淶���͡�
    /// </summary>
    System_ItemType,
    /// <summary>
    /// ����û��Ѻ��������ơ�
    /// </summary>
    System_ItemTypeText,
    /// <summary>
    /// ��ʾָ����ĸ�ʽ��ȷ�� URL��
    /// </summary>
    System_ItemUrl,
    /// <summary>
    /// �ؼ��ּ� (Ҳ��Ϊ��tags��) ��������
    /// </summary>
    System_Keywords,
    /// <summary>
    /// ��ͼ������չ�������ļ��С�
    /// </summary>
    System_Kind,
    /// <summary>
    /// <seealso cref="System_Kind">System.Kind</seealso> ���û��Ѻ���ʽ�� ��ֵ�����Ա�̷�ʽ�����ġ�
    /// </summary>
    System_KindText,
    /// <summary>
    /// �ļ�����Ҫ���ԣ������Ǹ��ļ����ĵ�ʱ��
    /// </summary>
    System_Language,
    /// <summary>
    /// 
    /// </summary>
    System_LastSyncError,
    /// <summary>
    /// Ӧ�������ı�ǡ� Ҫ�༭�ļ����ݵ���һ��Ӧ�õİ�ϵ�����ơ�
    /// </summary>
    System_LastWriterPackageFamilyName,
    /// <summary>
    /// ��ĵ����Ŷȹؼ��֡�
    /// </summary>
    System_LowKeywords,
    /// <summary>
    /// ����е����Ŷȹؼ��֡�
    /// </summary>
    System_MediumKeywords,
    /// <summary>
    /// 
    /// </summary>
    System_MileageInformation,
    /// <summary>
    /// MIME ���͡�
    /// </summary>
    System_MIMEType,
    /// <summary>
    /// 
    /// </summary>
    System_Null,
    /// <summary>
    /// 
    /// </summary>
    System_OfflineAvailability,
    /// <summary>
    /// 
    /// </summary>
    System_OfflineStatus,
    /// <summary>
    /// 
    /// </summary>
    System_OriginalFileName,
    /// <summary>
    /// ӵ�п���û��� SID��
    /// </summary>
    System_OwnerSID,
    /// <summary>
    /// �Ը�ʽ�洢�ļҳ��ּ�ͨ���� <seealso cref="System_ParentalRatingsOrganization">System.ParentalRatingsOrganization</seealso> ����������֯ȷ����
    /// </summary>
    System_ParentalRating,
    /// <summary>
    /// ˵���ļ��ּ���
    /// </summary>
    System_ParentalRatingReason,
    /// <summary>
    /// ��ּ�ϵͳ���� <seealso cref="System_ParentalRating">System.ParentalRating</seealso> ����֯�����ơ�
    /// </summary>
    System_ParentalRatingsOrganization,
    /// <summary>
    /// ���ڻ�ȡҪ��������� <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-ibindctx">IBindCtx</see> ��
    /// </summary>
    System_ParsingBindContext,
    /// <summary>
    /// ������ڸ��ļ��е� Shell �����ռ����ơ�
    /// </summary>
    System_ParsingName,
    /// <summary>
    /// ��� Shell �����ռ�·����
    /// </summary>
    System_ParsingPath,
    /// <summary>
    /// ������淶���͵ĸ�֪�ļ����͡�
    /// </summary>
    System_PerceivedType,
    /// <summary>
    /// ���Ŀռ������԰ٷֱȱ�ʾ����
    /// </summary>
    System_PercentFull,
    /// <summary>
    /// 
    /// </summary>
    System_Priority,
    /// <summary>
    /// <seealso cref="System_Priority">System.Priority</seealso> ���û��Ѻ���ʽ�� ��ֵ�����Ա�̷�ʽ�����ġ�
    /// </summary>
    System_PriorityText,
    /// <summary>
    /// 
    /// </summary>
    System_Project,
    /// <summary>
    /// 
    /// </summary>
    System_ProviderItemID,
    /// <summary>
    /// ʹ�ý��� 1 �� 99 ֮�������ֵ�ķּ�ϵͳ�� ���� Windows Vista Shell ʹ�õķּ�ϵͳ��
    /// </summary>
    System_Rating,
    /// <summary>
    /// <seealso cref="System_Rating">System.Rating</seealso> ���û��Ѻ���ʽ�� ��ֵ�����Ա�̷�ʽ�����ġ�
    /// </summary>
    System_RatingText,
    /// <summary>
    /// 
    /// </summary>
    System_RemoteConflictingFile,
    /// <summary>
    /// 
    /// </summary>
    System_Sensitivity,
    /// <summary>
    /// <seealso cref="System_Sensitivity">System.Sensitivity</seealso> ���û��Ѻ���ʽ�� ��ֵ�����Ա�̷�ʽ�����ġ�
    /// </summary>
    System_SensitivityText,
    /// <summary>
    /// <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellfolder-getattributesof">IShellFolder::GetAttributesOf</see> ��ʹ�õ� <see href="https://learn.microsoft.com/zh-cn/windows/win32/shell/sfgao">SFGAO</see> ֵ��
    /// </summary>
    System_SFGAOFlags,
    /// <summary>
    /// ָʾ����˭����
    /// </summary>
    System_SharedWith,
    /// <summary>
    /// 
    /// </summary>
    System_ShareUserRating,
    /// <summary>
    /// ָʾ��Ŀ�Ĺ���״̬����δ����������������ÿ���ˡ� (��ͥ���) ��ר�á���
    /// </summary>
    System_SharingStatus,
    /// <summary>
    /// ʡ�� Shell ��ͼ�е��
    /// </summary>
    System_Shell_OmitFromView,
    /// <summary>
    /// ʹ�ý��� 0 �� 5 ֮�������ֵ�ķּ�ϵͳ��
    /// </summary>
    System_SimpleRating,
    /// <summary>
    /// ���ϵͳ�ṩ���ļ�ϵͳ��С�����ֽ�Ϊ��λ����
    /// </summary>
    System_Size,
    /// <summary>
    /// 
    /// </summary>
    System_SoftwareUsed,
    /// <summary>
    /// 
    /// </summary>
    System_SourceItem,
    /// <summary>
    /// �洢��ʵ�������Ӧ�õİ�ϵ�����ơ�
    /// </summary>
    System_SourcePackageFamilyName,
    /// <summary>
    /// 
    /// </summary>
    System_StartDate,
    /// <summary>
    /// �����ڸ���ĳ���״̬��Ϣ��
    /// </summary>
    System_Status,
    /// <summary>
    /// �洢�ṩ������÷�Э��汾��Ϣ�������Եĸ�ʽ�ض����ṩ�����й���ϸ��Ϣ������Ĵ洢�ṩ�����ĵ���
    /// </summary>
    System_StorageProviderCallerVersionInformation,
    /// <summary>
    /// 
    /// </summary>
    System_StorageProviderError,
    /// <summary>
    /// �洢�ṩ����Ϊ�ļ������У��͡� ������ͬУ���ֵ���ļ���������ͬ�����ݡ�
    /// </summary>
    System_StorageProviderFileChecksum,
    /// <summary>
    /// ���ļ��Ĵ洢�ṩ�����ʶ����
    /// </summary>
    System_StorageProviderFileIdentifier,
    /// <summary>
    /// ���ļ��Ĵ洢�ṩ�����Զ�� URI��
    /// </summary>
    System_StorageProviderFileRemoteUri,
    /// <summary>
    /// ���ļ��Ĵ洢�ṩ�����ļ��汾��
    /// </summary>
    System_StorageProviderFileVersion,
    /// <summary>
    /// ���ļ��Ĵ洢�ṩ��������ļ��汾ˮ�ߡ� ��ֵ���ڼ���ļ��Ƿ��Ѹ��ġ�
    /// </summary>
    System_StorageProviderFileVersionWaterline,
    /// <summary>
    /// �����Ա�ʾ��ȫ�޶����ṩ�����ʶ���� [�洢 �ṩ���� ID] ��һ���֡�[�洢�ṩ���� ID]��[Windows SID]��[�ʻ� ID]����
    /// </summary>
    System_StorageProviderId,
    /// <summary>
    /// �����Ա�ʾ�洢�ṩ����ָ�����ļ�/�ļ��еĹ���״̬�б�ÿ������״̬����������StorageProviderShareStatuses ö��ָ������ֵ֪֮һ��ֻ�����ԣ���ֻ���ɴ洢�ṩ������¡�
    /// </summary>
    System_StorageProviderShareStatuses,
    /// <summary>
    /// �����Ա�ʾ�洢�ṩ����ָ�����ļ�/�ļ��е�����ɹ���״̬������״̬������ɵ����������Ϊ��ӵ�С�>����ͬӵ�С�>��������>������>��ר�á����洢�ṩ������״̬��ֻ�����ԡ�
    /// </summary>
    System_StorageProviderSharingStatus,
    /// <summary>
    /// 
    /// </summary>
    System_StorageProviderStatus,
    /// <summary>
    /// �ĵ������⡣ ������ӳ�䵽 OLE �ĵ����� Subject��
    /// </summary>
    System_Subject,
    /// <summary>
    /// 
    /// </summary>
    System_SyncTransferStatus,
    /// <summary>
    /// ��ʾVT_CF��ʽ������ͼ��
    /// </summary>
    System_Thumbnail,
    /// <summary>
    /// ������������ͼ�ļ���Ψһֵ��
    /// </summary>
    System_ThumbnailCacheId,
    /// <summary>
    /// ��VT_STREAM��ʽ��ʾ����ͼ�����ݣ�Windows GDI+��Windows�����������.jpg��.png��֧�֡�
    /// </summary>
    System_ThumbnailStream,
    /// <summary>
    /// ��ı��⡣
    /// </summary>
    System_Title,
    /// <summary>
    /// �˿�ѡ�ַ���ֵ������д <seealso cref="System_Title">System.Title</seealso> �ı�׼����˳���������ȷ���������е������ļ��ǳ���Ҫ���޷���ȷ���� (�û�Ԥ�ڵ�����) û�д��ֶΡ������������Զ���Ƕ��Ƿ����е��������������û�ɾ��������������¡�
    /// </summary>
    System_TitleSortOverride,
    /// <summary>
    /// 
    /// </summary>
    System_TotalFileSize,
    /// <summary>
    /// ����Ŀ�������̱꣬�����ַ�����ʽ��
    /// </summary>
    System_Trademarks,
    /// <summary>
    /// 
    /// </summary>
    System_TransferOrder,
    /// <summary>
    /// 
    /// </summary>
    System_TransferPosition,
    /// <summary>
    /// 
    /// </summary>
    System_TransferSize,
    /// <summary>
    /// NTFS ��� GUID��
    /// </summary>
    System_VolumeId,
    /// <summary>
    /// Web ����ı�ǣ���Ϊ URLZONE ö��ֵ��
    /// </summary>
    System_ZoneIdentifier
}
